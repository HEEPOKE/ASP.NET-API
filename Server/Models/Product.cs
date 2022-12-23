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
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? price { get; set; }
    }
}