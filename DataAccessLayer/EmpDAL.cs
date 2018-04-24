using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class EmpDAL
    {
        HRMDB context = new HRMDB();
        public IEnumerable<AspNetUser> GetEmps()
        {
            
            var list = context.AspNetUsers.ToList();
           
            return list;
        }
        public AspNetUser GetEmpById(string id)
        {
            var emp = context.AspNetUsers.Where(x => x.Id == id).SingleOrDefault(); 
            return emp;
        }
        public void CreateEmp(AspNetUser objasp)
        {
            context.AspNetUsers.Add(objasp);
            context.SaveChanges();
            
        }
        public AspNetUser UpdateEdit(string id)
        {
            var emp = context.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
            return emp;
        }
        public void EditEmp(AspNetUser objasp)
        {
            var emp = context.AspNetUsers.Where(x => x.Id == objasp.Id).SingleOrDefault();
            emp.Email = objasp.Email;
            emp.ImageName = objasp.ImageName;
            emp.PhoneNumber = objasp.PhoneNumber;
            context.SaveChanges();
        }
        //Fetch the  Particular Record Based On Id To Delete
        public AspNetUser DeleteEmp(string id)
        {
            var emp = UpdateEdit(id);
            return emp;
        }
        //Delete the Fetched Record Based On Id
        public void DeleteEmp1(string id)
        {
            var emp = context.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
            context.AspNetUsers.Remove(emp);
            context.SaveChanges();
        }
        // Display The Particular Details Based On the Id
        public AspNetUser Details(string id)
        {
            var emp = UpdateEdit(id);
            return emp;

        }
        public IEnumerable<AspNetUser> GetTeamMembers(string id)
        {
            var emp = GetEmpById(id);
            var deptlist = context.AspNetUsers.Where(x => x.DepartmentId == emp.DepartmentId).ToList();
            return deptlist;
        }
        public IEnumerable<Dept> GetDepts()
        {
            var listdept = context.Depts.ToList();
            return listdept;
        }
        public void CreateDept(Dept objDept)
        {
            context.Depts.Add(objDept);
            context.SaveChanges();
        }
        public Dept UpdateDept(string id)
        {
            var dept = context.Depts.Where(x => x.DepartmentId == id).FirstOrDefault();
            return dept;
        }
        public void EditDept(Dept objDept)
        {
            var dept = context.Depts.Where(x => x.DepartmentId == objDept.DepartmentId).SingleOrDefault();
            dept.DepartmentName = objDept.DepartmentName;
            context.SaveChanges();
        }
        public Dept DeleteDept(string id)
        {
            var dept = UpdateDept(id);
            return dept;
        }
        //Delete the Fetched Record Based On Id
        public void DeleteDept1(string id)
        {
            var dept = context.Depts.Where(x => x.DepartmentId == id).FirstOrDefault();
            context.Depts.Remove(dept);
            context.SaveChanges();
        }
        // Display The Particular Details Based On the Id
        public Dept DetailsDept(string id)
        {
            var dept = UpdateDept(id);
            return dept;

        }
        public void CreateFYear(FinancialYearDetail objFYD)
        {
            context.FinancialYearDetails.Add(objFYD);
            context.SaveChanges();

        }
        public AspNetUser AddFinancialReference(string id)
        {
            var data = context.AspNetUsers.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
        public void AddFinancialReference(AttendanceDetail objAD)
        {
            context.AttendanceDetails.Add(objAD);
            context.SaveChanges();
        }
      
        
    }
    }

