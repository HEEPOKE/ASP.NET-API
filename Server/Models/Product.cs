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
        public int id { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string? Description { get; set; }
        [Required]
        [MaxLength(200)]
        public int? price { get; set; }
    }
}
