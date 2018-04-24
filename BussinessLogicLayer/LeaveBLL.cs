using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer
{
   public class LeaveBLL
    {
        LeaveDAL objLeaveDAL = new LeaveDAL();
        public IEnumerable<LeaveDetail> GetLeaves()
        {
            return objLeaveDAL. GetLeaves();
        }
        public IEnumerable<LeaveDetail> GetLeaveById(string id)
        {
            return objLeaveDAL.GetleaveById(id);
        }
        public void Createleave(LeaveDetail objasp)
        {
            objLeaveDAL.CreateLeave(objasp);
        }
        public LeaveDetail UpdateEdit(int id)
        {
            return objLeaveDAL.UpdateEdit(id);
        }
        public void EditLeave(LeaveDetail objasp)
        {
            objLeaveDAL.EditLeave(objasp);
        }
        public LeaveDetail DeleteLeave(int  id)
        {
            return objLeaveDAL.DeleteLeave(id);
        }
        public void DeleteLeave1(int  id)
        {
            objLeaveDAL.DeleteLeave1(id);
        }
        public LeaveDetail Details(int id)
        {
            var leave = objLeaveDAL.Details(id);
            return leave;
        }
    }
}
