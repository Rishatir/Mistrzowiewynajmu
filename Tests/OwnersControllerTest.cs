using Microsoft.VisualStudio.TestTools.UnitTesting;
using MistrzowieWynajmu.Controllers;
using MistrzowieWynajmu.Models;
using System;

namespace Tests
{
    [TestClass]
    public class OwnersControllerTest
    {
        [TestMethod]
        public void TestDetailsViewData()
        {
            var orepoMock = new OwnerRepositoryMock();
            var controller = new OwnersController(orepoMock);
            Owner owner = new Owner("", "Kowalski", "555");

            Assert.ThrowsException<Exception>(() => controller.AddOwner(owner));
        }
    }
}