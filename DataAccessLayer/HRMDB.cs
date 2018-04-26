namespace DataAccessLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HRMDB : DbContext
    {
        public HRMDB()
            : base("name=HRMDB16")
        {
        }

        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AttendanceDetail> AttendanceDetails { get; set; }
        public virtual DbSet<Dept> Depts { get; set; }
        public virtual DbSet<FinancialYearDetail> FinancialYearDetails { get; set; }
        public virtual DbSet<LeaveDesc> LeaveDescs { get; set; }
        public virtual DbSet<LeaveDetail> LeaveDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUser>()
                .Property(e => e.DepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceDetail>()
                .Property(e => e.TotalDays)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceDetail>()
                .Property(e => e.TotalLeaves)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceDetail>()
                .Property(e => e.TotalWorkingDays)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceDetail>()
                .Property(e => e.TotalWorkingDaysTillDate)
                .IsUnicode(false);

            modelBuilder.Entity<AttendanceDetail>()
                .Property(e => e.financialId)
                .IsUnicode(false);

            modelBuilder.Entity<Dept>()
                .Property(e => e.DepartmentId)
                .IsUnicode(false);

            modelBuilder.Entity<Dept>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialYearDetail>()
                .Property(e => e.FinancialId)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialYearDetail>()
                .Property(e => e.FYearName)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialYearDetail>()
                .Property(e => e.NonWorkingDays)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialYearDetail>()
                .Property(e => e.TotalDays)
                .IsUnicode(false);

            modelBuilder.Entity<FinancialYearDetail>()
                .Property(e => e.TotalWorkingDays)
                .IsUnicode(false);
        }
    }
}
