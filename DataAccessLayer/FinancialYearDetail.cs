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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FinancialYearDetail()
        {
            AttendanceDetails = new HashSet<AttendanceDetail>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string FinancialId { get; set; }

        public DateTime? YearStart { get; set; }

        public DateTime? YearEnd { get; set; }

        [StringLength(50)]
        public string NonWorkingDays { get; set; }

        [StringLength(50)]
        public string TotalDays { get; set; }

        [StringLength(50)]
        public string TotalWorkingDays { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
