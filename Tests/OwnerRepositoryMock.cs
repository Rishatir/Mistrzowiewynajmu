using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class OwnerRepositoryMock : IOwnerRepository
    {
        public int AddOwner(Owner owner)
        {
            return 1;
        }

        public Owner GetOwner(int ownerId)
        {
            return new Owner("testName", "testSurname", "") { };
        }
    }
}