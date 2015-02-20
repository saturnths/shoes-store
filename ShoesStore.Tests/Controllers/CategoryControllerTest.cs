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
    public class CategoryControllerTest
    {
        CategoryController controller;

        [TestInitialize]
        public void TestSetup()
        {
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(p => p.Shoes).Returns(new Shoe[] {
                new Shoe { ShoeId = 1, Name = "Shoe Name 1", Gender = "men", Category = "Boots", Price = 65.00M },
                new Shoe { ShoeId = 2, Name = "Shoe Name 2", Gender = "women", Category = "Boots", Price = 67.30M },
                new Shoe { ShoeId = 3, Name = "Shoe Name 3", Gender = "men", Category = "Sandals", Price = 54.00M }
            });

            CategoryFactory categoryFactory = new CategoryFactory(mock.Object);
            controller = new CategoryController(mock.Object, categoryFactory);
        }

        /// <summary>
        /// check that the categories are as expected
        /// </summary>
        [TestMethod]
        public void GetCategories()
        {
            var categories = controller.Get().ToList();
            Assert.AreEqual(2, categories[0].Categories.Count());
            Assert.AreEqual(1, categories[1].Categories.Count());
            Assert.IsTrue(categories[0].Categories.ToList()[0].Equals("Boots"));
            Assert.IsTrue(categories[0].Categories.ToList()[1].Equals("Sandals"));
        }

    }
}
