using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public class PropertyRepositoryMock : IPropertyRepository
    {
        List<Property> properties = new List<Property>()
        {
            new Property(1,PropertyType.Flat,"Desc 1",1,1,true,true,true),
            new Property(2,PropertyType.Flat,"Desc 2",1,1,true,true,true),
            new Property(3,PropertyType.Flat,"Desc 3",1,1,true,true,true)};
        public int AddProperty(Property property, Address address, Owner owner)
        {
            throw new NotImplementedException();
        }

        public void DeleteProperty(Property property, Address address, Owner owner)
        {
            throw new NotImplementedException();
        }

        public List<Property> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public Property GetProperty(int propertyId)
        {
            return properties.Where(a => a.Id == propertyId).FirstOrDefault();
        }

        public int UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }
}
