using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("RegisterOrderQRScanHistory")]
    public partial class RegisterOrderQrscanHistory
    {
        [Key]
        public int Id { get; set; }
        public int RegisterOrderId { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateScanned { get; set; }
        public TimeSpan TimeScanned { get; set; }
        public int PointObtained { get; set; }

        [ForeignKey(nameof(RegisterOrderId))]
        [InverseProperty("RegisterOrderQrscanHistories")]
        public virtual RegisterOrder RegisterOrder { get; set; }
    }
}
