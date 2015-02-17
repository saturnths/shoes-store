using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesStore.Repository;
using ShoesStore.Factories;

namespace ShoesStore.Models
{
    // category group per gender
    public class CategoryGroup
    {
        public string Gender;
        public IEnumerable<string> Categories;

        public CategoryGroup(string gender, IEnumerable<string> categories)
        {
            Gender = gender;
            Categories = categories;
        }
    }
}