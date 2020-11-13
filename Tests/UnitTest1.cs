using Microsoft.VisualStudio.TestTools.UnitTesting;
using MistrzowieWynajmu.Controllers;
using MistrzowieWynajmu.Models;

namespace PropertyController
{
    [TestClass]
    public class PropertyController
    {
        [TestMethod]
        public void checkIfPropertyIdHasValidId()
        {
            // Avarage
            Property property = new Property
            {
                Id = 1,
                Description = "Description",
                Rooms = 3,
            };

            // Act
            int invalidId = 0;

            Assert.IsTrue((property.Id > invalidId), "Id must be greater then zero!");
        }

        [TestMethod]
        public void checkIfPropertyHasProperRoom()
        {
            // Avarage
            Property property = new Property
            {
                Id = 1,
                Description = "Description",
                Rooms = 3,
            };

            // Act
            int invalidRoomNumer = 0;

            Assert.IsTrue((property.Rooms > invalidRoomNumer), "Property must containt more than one room");
        }
    }
}
