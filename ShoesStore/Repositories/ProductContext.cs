using System;
using System.Data.Entity;
using ShoesStore.Models;

namespace ShoesStore.Repository
{
    public class ProductContext : DbContext
    {
        public DbSet<Shoe> Shoes { get; set; }
    }
}