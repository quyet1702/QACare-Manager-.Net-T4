using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    public partial class Tag
    {
        public Tag()
        {
            TagCustomers = new HashSet<TagCustomer>();
            TagPromotionGifts = new HashSet<TagPromotionGift>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Text { get; set; }
        [Required]
        [StringLength(250)]
        public string Slug { get; set; }

        [InverseProperty(nameof(TagCustomer.Tag))]
        public virtual ICollection<TagCustomer> TagCustomers { get; set; }
        [InverseProperty(nameof(TagPromotionGift.Tag))]
        public virtual ICollection<TagPromotionGift> TagPromotionGifts { get; set; }
    }
}
