using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
    public class EmpBLL
    {
        EmpDAL objEmpDAL = new EmpDAL();
        public IEnumerable<AspNetUser> GetEmps()
        {
            return objEmpDAL.GetEmps();
        }
        public AspNetUser GetEmpById(string id)
        {
            var emp= objEmpDAL.GetEmpById(id);
            return emp;
        }
        public void CreateEmp(AspNetUser objasp)
        {
            objEmpDAL.CreateEmp(objasp);
        }
        public AspNetUser UpdateEdit(string id)
        {
            return objEmpDAL.UpdateEdit(id);
        }
        public void EditEmp(AspNetUser objasp)
        {
            objEmpDAL.EditEmp(objasp);
        }
        public AspNetUser DeleteEmp(string id)
        {
            return objEmpDAL.DeleteEmp(id);
        }
        public void DeleteEmp1(string id)
        {
            objEmpDAL.DeleteEmp1(id);
        }
        public AspNetUser Details(string id)
        {
            var emp=  objEmpDAL.Details(id);
            return emp;
        }
        public IEnumerable<AspNetUser> GetTeamMembers(string id)
        {
            return objEmpDAL.GetTeamMembers(id);
        }
        public IEnumerable<Dept> GetDepts()
        {
            return objEmpDAL.GetDepts();
          
        }
        public void CreateDept(Dept objDept)
        {
            objEmpDAL.CreateDept(objDept);
        }
        public Dept UpdateDept(string id)
        {
            return objEmpDAL.UpdateDept(id);
        }
        public void EditDept(Dept objDept)
        {
            objEmpDAL.EditDept(objDept);
        }
        public Dept DeleteDept(string id)
        {
            return objEmpDAL.DeleteDept(id);
        }
        //Delete the Fetched Record Based On Id
        public void DeleteDept1(string id)
        {
            objEmpDAL.DeleteDept1(id);
        }
        // Display The Particular Details Based On the Id
        public Dept DetailsDept(string id)
        {
            var dept = objEmpDAL.DetailsDept(id);
            return dept;

        }
        public void CreateFYear(FinancialYearDetail objFYD)
        {
            objEmpDAL.CreateFYear(objFYD);
        }
       public AspNetUser AddFinancialReference(string id)
        {
            return objEmpDAL.AddFinancialReference(id);
        }
        public void AddFinancialReference(AttendanceDetail objAD)
        {
            objEmpDAL.AddFinancialReference(objAD);
        }
    }
}
