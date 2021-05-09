using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace QACareManagement.DataModel
{
    [Table("TagCustomer")]
    public partial class TagCustomer
    {
        [Key]
        public int TagId { get; set; }
        [Key]
        public int CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("TagCustomers")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(TagId))]
        [InverseProperty("TagCustomers")]
        public virtual Tag Tag { get; set; }
    }
}
