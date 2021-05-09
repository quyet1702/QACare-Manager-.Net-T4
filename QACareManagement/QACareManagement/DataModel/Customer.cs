using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            CustomerAddresses = new HashSet<CustomerAddress>();
            PromotionGifts = new HashSet<PromotionGift>();
            TagCustomers = new HashSet<TagCustomer>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(1000)]
        public string PasswordHash { get; set; }
        public int Role { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }
        public TimeSpan CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateAt { get; set; }

        [InverseProperty(nameof(CustomerAddress.Customer))]
        public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; }
        [InverseProperty(nameof(PromotionGift.DealerCustomer))]
        public virtual ICollection<PromotionGift> PromotionGifts { get; set; }
        [InverseProperty(nameof(TagCustomer.Customer))]
        public virtual ICollection<TagCustomer> TagCustomers { get; set; }
    }
}
