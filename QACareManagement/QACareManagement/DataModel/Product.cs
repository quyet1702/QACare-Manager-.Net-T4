using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("Product")]
    public partial class Product
    {
        public Product()
        {
            PromotionGiftProducts = new HashSet<PromotionGiftProduct>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(500)]
        public string Name { get; set; }

        [InverseProperty(nameof(PromotionGiftProduct.Product))]
        public virtual ICollection<PromotionGiftProduct> PromotionGiftProducts { get; set; }
    }
}
