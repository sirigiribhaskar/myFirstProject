namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class LeaveDetail
    {
        [Key]
        public int EventId { get; set; }

        [StringLength(128)]
        public string Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        [StringLength(128)]
        public string Description { get; set; }

        public bool? Status { get; set; }

        public int? LeaveId { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual LeaveDesc LeaveDesc { get; set; }
    }
}
