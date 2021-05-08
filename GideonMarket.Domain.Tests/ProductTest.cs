using GideonMarket.Domain.Models;
using NUnit.Framework;

namespace GideonMarket.Domain.Tests
{
    public class ProductTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Product product = new Product("wefwe", "werfgwe", 1, 1);
               
        }
    }
}