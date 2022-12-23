using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class Product
    {
        [Key]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public int? price { get; set; }
    }
}
