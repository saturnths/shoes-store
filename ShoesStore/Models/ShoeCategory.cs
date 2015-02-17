using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoesStore.Models
{
    public class ShoeCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string Name { get; set; }
    }
}