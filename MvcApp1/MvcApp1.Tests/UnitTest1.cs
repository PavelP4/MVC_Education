using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApp1.Models;
using System.Linq;
using System.Collections.Generic;

namespace MvcApp1.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private Product[] products = {
            new Product {Name = "Kayak", Category = "Watersports", Price = 275M},
            new Product {Name = "Lifejacket", Category = "Watersports", Price = 48.95M},
            new Product {Name = "Soccer ball", Category = "Soccer", Price = 19.50M},
            new Product {Name = "Corner flag", Category = "Soccer", Price = 34.95M}
        };

        [TestMethod]
        public void TestMethod1()
        {
            Mock<IValueCalculator> mock = new Mock<IValueCalculator>();
            mock.Setup(m => m.ValueProducts(It.IsAny<IEnumerable<Product>>()))
                .Returns<IEnumerable<Product>>(arr => arr.Sum(e => e.Price));

            //var target = new LinqValueCalculator();
            // act
            var result = mock.Object.ValueProducts(products);
            // assert
            Assert.AreEqual(products.Sum(e => e.Price), result);
        }

    }
}
