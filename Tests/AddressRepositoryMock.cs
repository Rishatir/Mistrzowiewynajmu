using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    public class AddressRepositoryMock : IAddressRepository
    {
        public int AddAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public Address GetAddress(int addressId)
        {
            throw new NotImplementedException();
        }
    }
}
