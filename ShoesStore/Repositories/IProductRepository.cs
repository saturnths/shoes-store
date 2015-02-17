using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesStore.Models;

namespace ShoesStore.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Shoe> Shoes { get; }
    }
}