using BussinessLogicLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace HRM.Controllers
{
    public class EmpController : Controller
    {
        // GET: Emp
        LeaveBLL objLeaveBLL = new LeaveBLL();
        EmpBLL objEmpBLL = new EmpBLL();
        private HRMDB context = new HRMDB();

        public int? Dept { get; private set; }

        //------------------------------Employee Personal Details--------------------------//

        public ActionResult EmptyLayout()
        {
            return View();
        }
        public ActionResult EmptyAdminLayout()
        {
            return View();
        }

        //Empty View for default Emp Login
        public ActionResult EmpAdmin(string id)
        {
            Session["id"] = id;
            var emp = GetEmpByid(id);
            return View(emp);

        }
        //Empty View for default Emp Login
        public ActionResult Empty(string id)
        {
            Session["id"] = id;
            var emp = GetEmpByid(id);
            return View(emp);
        }
        // Displaying all the Emplopye Personal Details
        public ActionResult Index()
        {
            var emp = objEmpBLL.GetEmps();
            return View(emp);
        }
        //Displaying Particular Employee Details List Based on the ID
        [HttpGet]

       
        public ActionResult GetEmpByid(string id)
        {
            id = Session["id"].ToString();
            var details = objEmpBLL.GetEmpById(id);
            //Session["id"] = details.Id;
            return View(details);
        }
        //Editing  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult Edit(string id)
        {

            var emp = objEmpBLL.UpdateEdit(id);
            //Session["Empid"] = emp.Id;
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            return View(emp);

        }

        [HttpPost]
        public ActionResult Edit(AspNetUser objasp, HttpPostedFileBase UploadedImage)
        {
            if (UploadedImage.ContentLength > 0 )
            {
                string ImageFileName = Path.GetFileName(UploadedImage.FileName);
                string Folderpath = Path.Combine(Server.MapPath("~/UploadedImages"), ImageFileName);
                UploadedImage.SaveAs(Folderpath);

            }
            var image = UploadedImage.FileName;
            objasp.ImageName = image;
            objEmpBLL.EditEmp(objasp); HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            //string id = Session["id"].ToString();
            //string id = Session["Empid"].ToString();
            if (empdata.DepartmentId == "D4")
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("GetEmpByid", "Emp", new { ide });
            }
        }
        //Deleting  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult Delete(string id)
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var emp = objEmpBLL.DeleteEmp(id);
            return View(emp);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete1(string id)
        {
            objEmpBLL.DeleteEmp1(id);
            return RedirectToAction("Index");
        }
        //Displaying the  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult Details(string id)
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var emp = objEmpBLL.Details(id);
            return View(emp);
        }
        //-----------------------------Employee Leave Details---------------------------------//
        //Displaying all the Emplopye Leave Details 
        public ActionResult GetLeaves()
        {
            var leaves = objLeaveBLL.GetLeaves();
            return View(leaves);
        }
        //Displaying all the Emplopye Leave Details  With the Particular ID
        public ActionResult GetLeaveById(string id)
        {
            HRMDB objHRMEmp = new HRMDB();
            id = Session["id"].ToString();
            //var data = (from x in objHRMEmp.AspNetUsers where x.Id == model.id select x).SingleOrDefault();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == id select x).SingleOrDefault();
            string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var leavedetails = objLeaveBLL.GetLeaveById(id);
            return View(leavedetails);
        }
        //Creating a New Leave Based On The ID
        [HttpGet]
        public ActionResult CreateLeave()
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
             var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
           string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            //HRMDB objHRMEmp = new HRMDB();
            IEnumerable<SelectListItem> Dept1 = objHRMEmp.LeaveDescs.Select(p => new SelectListItem
            {
                Value = p.LeaveId.ToString(),
                Text = p.Description

            });
            ViewData["YourData"] = Dept1;
            return View();
        }
        [HttpPost]
        public ActionResult CreateLeave(LeaveDetail objleave)
        {
           
            objleave.Id = Session["id"].ToString();
            objLeaveBLL.Createleave(objleave);
            //objleave.Id = Session["id"].ToString();
            string id = objleave.Id;
            return RedirectToAction("GetLeaveById", "Emp", new { id });
        }
        //Editing The Leave Based On The ID
        [HttpGet]
        public ActionResult EditLeave(int id)
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
           string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var leave = objLeaveBLL.UpdateEdit(id);
            return View(leave);
        }
        [HttpPost]
        public ActionResult EditLeave(LeaveDetail objasp)
        {
            objLeaveBLL.EditLeave(objasp);
            string id = Session["id"].ToString();
            return RedirectToAction(id, "Emp/GetLeaveById/");
        }
        //Deleting The Leave Based On The ID
        [HttpGet]
        public ActionResult Deleteleave(int id)
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            string Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var leave = objLeaveBLL.DeleteLeave(id);
            return View(leave);
        }
        [HttpPost]
        [ActionName("Deleteleave")]
        public ActionResult DeleteLeave1(int id)
        {
            objLeaveBLL.DeleteLeave1(id);
            string id1 = Session["id"].ToString();
            return RedirectToAction(id1, "Emp/GetLeaveById/");
        }
        //Displaying  The Leave Based On The ID
        [HttpGet]
        public ActionResult DetailsLeave(int id)
        {
            HRMDB objHRMEmp = new HRMDB();
            string ide = Session["id"].ToString();
            var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
           string  Dept = empdata.DepartmentId;
            ViewBag.deptid = Dept;
            var leave = objLeaveBLL.Details(id);
            return View(leave);
        }
        //-------------------------------Admin Leave Details----------------------------//
        //Approving The Emp Leave Based on the leave Evenet ID
        [HttpGet]
        public ActionResult EditLeaveAdmin(int id)
        {
            var leave = objLeaveBLL.UpdateEdit(id);
            return View(leave);
        }
        [HttpPost]
        public ActionResult EditLeaveAdmin(LeaveDetail objasp)
        {
            objLeaveBLL.EditLeave(objasp);
            return RedirectToAction("/GetLeaves");
        }
        //Deleting The Emp Leave Based on the leave Evenet ID
        [HttpGet]
        public ActionResult DeleteleaveAdmin(int id)
        {
            var leave = objLeaveBLL.DeleteLeave(id);
            return View(leave);
        }
        [HttpPost]
        [ActionName("DeleteleaveAdmin")]
        public ActionResult DeleteLeaveAdmin1(int id)
        {
            objLeaveBLL.DeleteLeave1(id);

            return RedirectToAction("/GetLeaves");
        }
        //Displaying  The Emp Leave Based on the leave Evenet ID
        [HttpGet]
        public ActionResult DetailsLeaveAdmin(int id)
        {
            var leave = objLeaveBLL.Details(id);
            return View(leave);
        }
        //
        [HttpGet]
        public ActionResult GetTeamMemberes(string id)
        {

            id = Session["id"].ToString();
            var team = objEmpBLL.GetTeamMembers(id);
            return View(team);
        }
        public ActionResult ExportEmpData()
        {
            HRMDB objHRMEmp = new HRMDB();
            GridView gv = new GridView();
            gv.DataSource = objHRMEmp.AspNetUsers.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=EmployeeDetails.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }
        public ActionResult ExportLeaveData()
        {
            HRMDB objHRMEmp = new HRMDB();
            GridView gv = new GridView();
            gv.DataSource = objHRMEmp.LeaveDetails.ToList();
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=LeaveDetails.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return RedirectToAction("Index");
        }

        public ActionResult Emplist()
        {
            return View();
        }

        public ActionResult Loaddata()
        {
            HRMDB objHRMEmp = new HRMDB();
            var emp = objHRMEmp.AspNetUsers.OrderBy(x => x.Id).ToList();
            return Json(new { data = emp }, JsonRequestBehavior.AllowGet);
        }

        // Displaying all the Emplopye Personal Details
        public ActionResult GetDepts()
        {

            var dept = objEmpBLL.GetDepts();
            return View(dept);
        }
        [HttpGet]
        public ActionResult CreateDept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateDept(Dept objdept)
        {

            //objleave.Id = Session["id"].ToString();
            //objLeaveBLL.crea(objdept);

            objEmpBLL.CreateDept(objdept);
            //objleave.Id = Session["id"].ToString();
            //string id = objleave.Id;
            return RedirectToAction("GetDepts", "Emp"/* new { id }*/);
        }
        //Displaying Particular Employee Details List Based on the ID
        //[HttpGet]

        //public ActionResult GetEmpByid(string id)
        //{
        //    id = Session["id"].ToString();
        //    var details = objEmpBLL.GetEmpById(id);
        //    //Session["id"] = details.Id;
        //    return View(details);
        //}
        //Editing  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult EditDept(string id)
        {

            var dept = objEmpBLL.UpdateDept(id);
            //Session["Empid"] = emp.Id;
            //HRMDB objHRMEmp = new HRMDB();
            //string ide = Session["id"].ToString();
            //var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            //Dept = empdata.Deptid;
            //ViewBag.deptid = Dept;
            return View(dept);

        }

        [HttpPost]
        public ActionResult EditDept(Dept objDept)
        {

            objEmpBLL.EditDept(objDept);
            //string id = Session["id"].ToString();
            //string id = Session["Empid"].ToString();
            return RedirectToAction("GetDepts", "Emp");
        }
        //Deleting  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult DeleteDept(string id)
        {
            //HRMDB objHRMEmp = new HRMDB();
            //string ide = Session["id"].ToString();
            //var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            //Dept = empdata.Deptid;
            //ViewBag.deptid = Dept;
            var dept = objEmpBLL.DeleteDept(id);
            return View(dept);
        }
        [HttpPost]
        [ActionName("DeleteDept")]
        public ActionResult DeleteDept1(string id)
        {
            objEmpBLL.DeleteDept1(id);
            return RedirectToAction("GetDepts");
        }
        //Displaying the  Particular Employee Details Based on the ID
        [HttpGet]
        public ActionResult DetailsDept(string id)
        {
            //HRMDB objHRMEmp = new HRMDB();
            //string ide = Session["id"].ToString();
            //var empdata = (from x in objHRMEmp.AspNetUsers where x.Id == ide select x).SingleOrDefault();
            //Dept = empdata.Deptid;
            //ViewBag.deptid = Dept;
            var dept = objEmpBLL.DetailsDept(id);
            return View(dept);
        }

        public ActionResult GetCount(string id)
        {
            AspNetUser context = new AspNetUser();
            List<LeaveDetail> leave = context.LeaveDetails.Where(x => x.Id == id && x.Status==true).ToList();
            return View(leave);
        }
        [HttpGet]
        public ActionResult CreateFYear()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFYear(FinancialYearDetail objFYD)
        {
            DateTime yearstart = Convert.ToDateTime(objFYD.YearStart.ToString());
            DateTime yearend = Convert.ToDateTime(objFYD.YearEnd.ToString());
            string Totaldays = yearend.Subtract(yearstart).TotalDays.ToString();
            objFYD.TotalDays = Totaldays;
            int Totalworkingdays = int.Parse(Totaldays) - int.Parse(objFYD.NonWorkingDays);
            objFYD.TotalWorkingDays = Totalworkingdays.ToString();
            objEmpBLL.CreateFYear(objFYD);
            return View();
        }
        [HttpGet]
        public ActionResult AddFinancialReference(string id)
        {
            HRMDB objHRMEmp = new HRMDB();
           
            IEnumerable<SelectListItem> Dept = context.FinancialYearDetails.Select(p => new SelectListItem
            {
                Value = p.FinancialId,
                Text = p.FYearName

            });
            ViewData["YourData"] = Dept;
            return View();
        }
        [HttpPost]
        public ActionResult AddFinancialReference(AttendanceDetail objAD)
        {
            HRMDB objHRMEmp = new HRMDB();
            var data = (from x in objHRMEmp.FinancialYearDetails.Where(x => x.FinancialId == objAD.financialId) select x).SingleOrDefault();
            int count = (from x in objHRMEmp.LeaveDetails where x.Status == true && x.Id == objAD.Id select x).Count();
            DateTime enddate = Convert.ToDateTime(data.YearEnd);
            DateTime joindate = Convert.ToDateTime(objAD.JoiningDate);
            string nonworkingdays = data.NonWorkingDays;
            string totaldays = enddate.Subtract(joindate).TotalDays.ToString();
            int totaldaysafternonworkingdays = int.Parse(totaldays) - int.Parse(nonworkingdays);
            string totalleaves = count.ToString();
            int totalworkingdays = (totaldaysafternonworkingdays) - int.Parse(count.ToString());
            DateTime currentdate = DateTime.Now;
            string totalworkingdaystilldate = currentdate.Subtract(joindate).TotalDays.ToString();
            objAD.Id = objAD.Id;
            objAD.TotalDays = totaldaysafternonworkingdays.ToString();
            objAD.TotalLeaves = totalleaves;
            objAD.TotalWorkingDays = totalworkingdays.ToString();
            objAD.TotalWorkingDaysTillDate = totalworkingdaystilldate;
            objAD.financialId = data.FinancialId.ToString();
            objEmpBLL.AddFinancialReference(objAD);
            return View();
        }
        [HttpGet]
        public ActionResult demodetails(Demo obj)
        {
            Demo demonew = new Demo();
            HRMDB objHRMEmp = new HRMDB();
            var ddd = (from x in objHRMEmp.AttendanceDetails.Where(x => x.Id == obj.Id) select x).SingleOrDefault();
            string i = ddd.financialId;
            DateTime date = Convert.ToDateTime(DateTime.Now.Date.ToString());
            DateTime joindate = Convert.ToDateTime(ddd.JoiningDate.ToString());
            var data = (from x in objHRMEmp.FinancialYearDetails.Where(x => x.FinancialId == i) select x).SingleOrDefault();
            int count = (from x in objHRMEmp.LeaveDetails where x.Status == true && x.Id == obj.Id select x).Count();
            var username = (from x in objHRMEmp.AspNetUsers.Where(x => x.Id == obj.Id) select x).SingleOrDefault();
            demonew.Id = username.UserName;
            demonew.Totaldays = ddd.TotalDays;
            demonew.Totalleaes = count.ToString();
            int totatworking = int.Parse(demonew.Totaldays) - int.Parse(demonew.Totalleaes);
            string totalworkingtilldate = date.Subtract(joindate).TotalDays.ToString();
            int totalworkingtilldatewithleave = int.Parse(totalworkingtilldate) - int.Parse(demonew.Totalleaes);
            demonew.Totalworkingdaystilldate = totalworkingtilldatewithleave.ToString();
            demonew.Totalworkingdays = totatworking.ToString();
            ViewData["Demo"] = demonew;
            return View();
        }
    }
}