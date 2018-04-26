namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FinancialYearDetail")]
    public partial class FinancialYearDetail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string FinancialId { get; set; }

        [StringLength(50)]
        public string FYearName { get; set; }

        public DateTime? YearStart { get; set; }

        public DateTime? YearEnd { get; set; }

        [StringLength(50)]
        public string NonWorkingDays { get; set; }

        [StringLength(50)]
        public string TotalDays { get; set; }

        [StringLength(50)]
        public string TotalWorkingDays { get; set; }
    }
}
