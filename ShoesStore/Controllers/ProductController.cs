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
    public class ProductController : ApiController
    {
        private IProductRepository repo;
        ProductFactory productFactory;
        //Logger Log;

        public ProductController(IProductRepository repo, ProductFactory productFactory)
        {
            this.repo = repo;
            this.productFactory = productFactory;
        }

        // GET api/product
        // return all products in stock
        public IEnumerable<Shoe> Get()
        {
            return repo.Shoes;
        }

        // GET api/product/id
        // return a product with this id
        public HttpResponseMessage Get(int id)
        {
            var product = productFactory.getProduct(id);

            if (product == null) {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Product not found");
            }

            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // GET api/product?gender=gender&category=category
        // return all shoes for gender and category provided
        public IEnumerable<Shoe> Get(string gender, string category)
        {
            return repo.Shoes.Where(s => s.Gender.Equals(gender) && s.Category.ToLower().Equals(category));
        }

    }
}