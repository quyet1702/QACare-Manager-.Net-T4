using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("PromotionGiftProduct")]
    public partial class PromotionGiftProduct
    {
        public int ProductId { get; set; }
        public int PromotionGiftId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty("PromotionGiftProducts")]
        public virtual Product Product { get; set; }
        [ForeignKey(nameof(PromotionGiftId))]
        [InverseProperty("PromotionGiftProducts")]
        public virtual PromotionGift PromotionGift { get; set; }
    }
}
