using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("PromotionGiftImageUpload")]
    public partial class PromotionGiftImageUpload
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(2000)]
        public string FileLocation { get; set; }
        public int PromotionGiftId { get; set; }
        [Required]
        [StringLength(250)]
        public string FileName { get; set; }

        [ForeignKey(nameof(PromotionGiftId))]
        [InverseProperty("PromotionGiftImageUploads")]
        public virtual PromotionGift PromotionGift { get; set; }
    }
}
