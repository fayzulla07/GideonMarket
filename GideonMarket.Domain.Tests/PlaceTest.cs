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
            Place place = new Place("�����1", Enums.PlaceType.WareHouse);
            // Act
           
        }
    }
}