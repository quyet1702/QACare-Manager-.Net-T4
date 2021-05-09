using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("TagPromotionGift")]
    public partial class TagPromotionGift
    {
        [Key]
        public int TagId { get; set; }
        [Key]
        public int PromotionGiftId { get; set; }

        [ForeignKey(nameof(PromotionGiftId))]
        [InverseProperty("TagPromotionGifts")]
        public virtual PromotionGift PromotionGift { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("TagPromotionGifts")]
        public virtual Tag Tag { get; set; }
    }
}
