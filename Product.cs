using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Producer { get; set; }
        [Required]
        [StringLength(50)]
        public string Supplier { get; set; }
        public decimal Price { get; set; }
    }
}