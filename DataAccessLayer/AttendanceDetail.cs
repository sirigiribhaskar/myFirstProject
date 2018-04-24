namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AttendanceDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Lid { get; set; }

        public string Id { get; set; }

        public DateTime? JoiningDate { get; set; }

        [StringLength(50)]
        public string TotalDays { get; set; }

        [StringLength(50)]
        public string TotalLeaves { get; set; }

        [StringLength(50)]
        public string TotalWorkingDays { get; set; }

        [StringLength(50)]
        public string TotalWorkingDaysTillDate { get; set; }

        [StringLength(256)]
        public string UserName { get; set; }

        [StringLength(50)]
        public string financialId { get; set; }

        public virtual FinancialYearDetail FinancialYearDetail { get; set; }
    }
}
