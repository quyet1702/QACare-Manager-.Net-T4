using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("RegisterOrder")]
    public partial class RegisterOrder
    {
        public RegisterOrder()
        {
            RegisterOrderQrscanHistories = new HashSet<RegisterOrderQrscanHistory>();
        }

        [Key]
        public int Id { get; set; }
        [Column(TypeName = "date")]
        public DateTime DateCreate { get; set; }
        public TimeSpan TimeCreate { get; set; }
        public int CustomerId { get; set; }
        public int PromotionGiftId { get; set; }
        public int CustomerDeliveryAddressId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateAt { get; set; }
        [StringLength(500)]
        public string Note { get; set; }

        [ForeignKey(nameof(CustomerDeliveryAddressId))]
        [InverseProperty(nameof(CustomerAddress.RegisterOrders))]
        public virtual CustomerAddress CustomerDeliveryAddress { get; set; }
        [ForeignKey(nameof(PromotionGiftId))]
        [InverseProperty("RegisterOrders")]
        public virtual PromotionGift PromotionGift { get; set; }
        [InverseProperty(nameof(RegisterOrderQrscanHistory.RegisterOrder))]
        public virtual ICollection<RegisterOrderQrscanHistory> RegisterOrderQrscanHistories { get; set; }
    }
}
