using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MistrzowieWynajmu.Models;

namespace Tests
{
    [TestClass]
    public class PropertyControllerTest
    {
        [TestMethod]
        public void GetPropertyTest()
        {
            int propertyId = 1;
            PropertyRepositoryMock propertyRepositoryMock = new PropertyRepositoryMock();
            var orepoMock = new OwnerRepositoryMock();
            AddressRepositoryMock addressRepositoryMock = new AddressRepositoryMock();
            var controller = new MistrzowieWynajmu.Controllers.PropertyController(propertyRepositoryMock, orepoMock, addressRepositoryMock);
            var result = controller.GetProperty(propertyId) as JsonResult;
            var property = (Property)(result.Value);

            Assert.AreEqual(propertyId, property.Id);
        }
    }
}