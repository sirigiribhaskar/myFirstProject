using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class LeaveDAL
    {
        HRMDB context = new HRMDB();
        public IEnumerable<LeaveDetail> GetLeaves()
        {
            return context.LeaveDetails.ToList();
        }
        public IEnumerable<LeaveDetail> GetleaveById(string id)
        {
            //var abc = from z in context.AspNetUsers.Where(z => z.Id == id) select z;

            var leavedetails =( from z in context.LeaveDetails.Where(z => z.Id == id)select z).ToList();
            var leave = context.LeaveDetails.Where(x => x.Id == id).ToList();
            return leave;
        }
        public void CreateLeave(LeaveDetail objLeaveDetail)
        {
            context.LeaveDetails.Add(objLeaveDetail);
            context.SaveChanges();
        }
        public LeaveDetail UpdateEdit(int  id)
        {
            var leave = context.LeaveDetails.Where(x => x.EventId == id).FirstOrDefault();
            return leave;
        }
        public void EditLeave(LeaveDetail objasp)
        {
            var leave = context.LeaveDetails.Where(x => x.EventId == objasp.EventId).SingleOrDefault();
            leave.StartDate = objasp.StartDate;
            leave.EndDate = objasp.EndDate;
            leave.Description = objasp.Description;
            leave.Status = objasp.Status;
            context.SaveChanges();
        }
        //Fetch the  Particular Record Based On Id To Delete
        public LeaveDetail DeleteLeave(int  id)
        {
            var leave = UpdateEdit(id);
            return leave;
        }
        //Delete the Fetched Record Based On Id
        public void DeleteLeave1(int  id)
        {
            var leave = context.LeaveDetails.Where(x => x.EventId == id).FirstOrDefault();
            context.LeaveDetails.Remove(leave);
            context.SaveChanges();
        }
        // Display The Particular Details Based On the Id
        public LeaveDetail Details(int  id)
        {
            var leave = UpdateEdit(id);
            return leave;

        }

    }
}
