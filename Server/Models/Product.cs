using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Models
{
    public class Product
    {

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int? price { get; set; }
    }
}