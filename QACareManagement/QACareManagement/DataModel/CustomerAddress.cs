using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("CustomerAddress")]
    public partial class CustomerAddress
    {
        public CustomerAddress()
        {
            PromotionGifts = new HashSet<PromotionGift>();
            RegisterOrders = new HashSet<RegisterOrder>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string StreetAddress { get; set; }
        [StringLength(50)]
        public string Ward { get; set; }
        [StringLength(50)]
        public string Province { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public int CustomerId { get; set; }
        [StringLength(100)]
        public string LatLong { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("CustomerAddresses")]
        public virtual Customer Customer { get; set; }
        [InverseProperty(nameof(PromotionGift.RegisterLocationCustomerAddress))]
        public virtual ICollection<PromotionGift> PromotionGifts { get; set; }
        [InverseProperty(nameof(RegisterOrder.CustomerDeliveryAddress))]
        public virtual ICollection<RegisterOrder> RegisterOrders { get; set; }
    }
}
