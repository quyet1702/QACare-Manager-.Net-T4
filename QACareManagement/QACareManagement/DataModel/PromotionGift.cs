using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("PromotionGift")]
    public partial class PromotionGift
    {
        public PromotionGift()
        {
            PromotionGiftImageUploads = new HashSet<PromotionGiftImageUpload>();
            PromotionGiftProducts = new HashSet<PromotionGiftProduct>();
            RegisterOrders = new HashSet<RegisterOrder>();
            TagPromotionGifts = new HashSet<TagPromotionGift>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "date")]
        public DateTime StartDateRunning { get; set; }
        [Column(TypeName = "date")]
        public DateTime EndRunRunning { get; set; }
        public int TotalPointRelease { get; set; }
        public int TotalPointEachRegister { get; set; }
        public int NumOfTotalRegisterAllow { get; set; }
        public int NumOfPointEachScan { get; set; }
        public int NumOfAllowScanDaily { get; set; }
        public TimeSpan? StarTimeAllowScanDaily { get; set; }
        public TimeSpan? EndTimeAllowScanDaily { get; set; }
        [Column(TypeName = "date")]
        public DateTime CreateDate { get; set; }
        public TimeSpan CreateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime UpdateAt { get; set; }
        public short Type { get; set; }
        public int? DealerCustomerId { get; set; }
        public int? RegisterLocationCustomerAddressId { get; set; }

        [ForeignKey(nameof(DealerCustomerId))]
        [InverseProperty(nameof(Customer.PromotionGifts))]
        public virtual Customer DealerCustomer { get; set; }
        [ForeignKey(nameof(RegisterLocationCustomerAddressId))]
        [InverseProperty(nameof(CustomerAddress.PromotionGifts))]
        public virtual CustomerAddress RegisterLocationCustomerAddress { get; set; }
        [InverseProperty(nameof(PromotionGiftImageUpload.PromotionGift))]
        public virtual ICollection<PromotionGiftImageUpload> PromotionGiftImageUploads { get; set; }
        [InverseProperty(nameof(PromotionGiftProduct.PromotionGift))]
        public virtual ICollection<PromotionGiftProduct> PromotionGiftProducts { get; set; }
        [InverseProperty(nameof(RegisterOrder.PromotionGift))]
        public virtual ICollection<RegisterOrder> RegisterOrders { get; set; }
        [InverseProperty(nameof(TagPromotionGift.PromotionGift))]
        public virtual ICollection<TagPromotionGift> TagPromotionGifts { get; set; }
    }
}
