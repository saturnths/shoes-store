using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesStore.Repository;
using ShoesStore.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;

namespace ShoesStore.Factories
{
    public class ProductFactory
    {
        IProductRepository repo;

        public ProductFactory(IProductRepository repo)
        {
            this.repo = repo;
        }

        public Shoe getProduct(int id)
        {
            return repo.Shoes.Where(s => s.ShoeId == id).FirstOrDefault();
        }
    }
}