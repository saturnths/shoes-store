using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using ShoesStore.Models;
using ShoesStore.Repository;
using ShoesStore.Factories;

namespace ShoesStore.Controllers
{
    public class CategoryController : ApiController
    {
        private IProductRepository repo;
        private CategoryFactory categoryFactory;
        //Logger Log;

        public CategoryController(IProductRepository repo, CategoryFactory categoryFactory)
        {
            this.repo = repo;
            this.categoryFactory = categoryFactory;
        }

        // GET api/category
        // return all categories for both genders
        public IEnumerable<CategoryGroup> Get()
        {
            return categoryFactory.getList();
        }

    }
}