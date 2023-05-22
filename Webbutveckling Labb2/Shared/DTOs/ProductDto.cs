using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Webbutveckling_Labb2.Shared.DTOs
{
    public class ProductDto
    {
        public string Id { get; set; }
        [Required]
        public string ProductNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public string Category { get; set;}
        [Required]
        public string Status { get; set; }
    }
}
