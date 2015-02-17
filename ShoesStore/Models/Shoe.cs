using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoesStore.Models
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public decimal? Price { get; set; }
    }
}