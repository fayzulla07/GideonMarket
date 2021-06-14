using GideonMarket.Entities.Models;
using NUnit.Framework;
using System.Linq;
namespace GideonMarket.Entities.Tests
{
    public class PlaceTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            Place place = new Place("Склад1", Enums.PlaceType.WareHouse);
            // Act
            place.AddProductToPlace(1, 10);
            place.MakeOrder(1, 2);
            place.CancelOrder(0, 2);

            // Assert
            Assert.IsNotNull(place.PlaceItems);
            Assert.IsTrue(place.PlaceItems.FirstOrDefault().RemainCount == 10);
        }
    }
}