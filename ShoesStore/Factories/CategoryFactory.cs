using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesStore.Repository;
using ShoesStore.Models;

namespace ShoesStore.Factories
{
    public class CategoryFactory
    {
        IProductRepository repository;

        public CategoryFactory(IProductRepository repo)
        {
            repository = repo;
        }

        private IEnumerable<string> GetCategoryGroups(string gender)
        {
            return repository.Shoes.Where(s => s.Gender.Equals(gender)).Select(s => s.Category).Distinct();
        }

        private CategoryGroup createCategoryGroup(string gender)
        {
            return new CategoryGroup(gender, GetCategoryGroups(gender));
        }

        public List<CategoryGroup> getList()
        {
            return new List<CategoryGroup>() {
                createCategoryGroup("men"),
                createCategoryGroup("women")
            };
        }
    }
}