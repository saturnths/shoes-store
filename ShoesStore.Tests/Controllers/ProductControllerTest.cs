using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoesStore;
using ShoesStore.Controllers;
using ShoesStore.Repository;
using ShoesStore.Models;
using ShoesStore.Factories;

namespace ShoesStore.Tests.Controllers
{
    [TestClass]
    public class ProductControllerTest
    {
        ProductController controller;

        [TestInitialize]
        public void TestSetup()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Shoes).Returns(new Shoe[] {
                new Shoe { ShoeId = 1, Name = "Shoe Name 1", Gender = "men", Category = "Boots", Price = 65.00M },
                new Shoe { ShoeId = 2, Name = "Shoe Name 2", Gender = "women", Category = "Boots", Price = 67.30M },
                new Shoe { ShoeId = 3, Name = "Shoe Name 3", Gender = "men", Category = "Sandals", Price = 54.00M }
            });

            ProductFactory productFactory = new ProductFactory(mock.Object);
            controller = new ProductController(mock.Object, productFactory);
        }

        [TestMethod]
        public void GetAll()
        {
            var allShoes = controller.Get().ToList();
            Assert.IsTrue(allShoes[0].Name.Equals("Shoe Name 1") && allShoes[0].Category.Equals("Boots"));
            Assert.AreEqual(3, allShoes.ToList().Count);
        }

    }
}
