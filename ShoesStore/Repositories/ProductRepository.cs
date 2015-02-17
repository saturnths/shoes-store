using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesStore.Models;

namespace ShoesStore.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ProductContext db = new ProductContext();

        public IEnumerable<Shoe> Shoes
        {
            get { return db.Shoes; }
        }
    }
}