using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Models.Interfaces;
using MistrzowieWynajmu.Models;

namespace MistrzowieWynajmu.Controllers
{
	[Produces("application/json")]
	[Route("api/Property")]
	public class PropertyController : Controller
	{
		private readonly IPropertyRepository _propertyRepository;
		private readonly IAddressRepository _addressRepository;
		private readonly IOwnerRepository _ownerRepository;

		public PropertyController(IPropertyRepository propertyRepository, 
								  IOwnerRepository ownerRepository, 
								  IAddressRepository addressRepository)
		{
			_propertyRepository = propertyRepository;
			_addressRepository = addressRepository;
			_ownerRepository = ownerRepository;
		}

		[HttpGet("[action]")]
		
		/// <summary>
		/// Get Properties list
		/// </summary>

		public IActionResult GetProperties()  
		{
			return new JsonResult(_propertyRepository.GetAllProperties()); /// wywolanie metody pobierajacej nieruchomosci
		}

		[HttpPost("[action]")]

		/// <summary>
		/// Add property
		/// </summary>
		/// <param name="FromBody"> Id: int, Type: PropertyType, Description: string, Rooms: int, Area: int, Washer: bool, Refigerator: bool, Iron: bool, AddressId: int, Address: Address, OwnerId: int, Owner: Owner} </param>
		public IActionResult AddProperty([FromBody] Property property) 
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var owner = _ownerRepository.GetOwner(property.OwnerId);
			if(owner == null)
			{
				return NotFound("Cannot find owner with provided ownerId.");
			}

			var address = _addressRepository.GetAddress(property.AddressId);
			if(address == null)
			{
				return NotFound("Cannot find address with provided addressId.");
			}

			_propertyRepository.AddProperty(property, address, owner);
			return new JsonResult(property.Id);
		}

		[HttpGet("[action]")]
		/// <summary>
		/// Show properties index
		/// </summary>
		/// <param name="propertyid"> is a parameter which show property index. </param>
		public IActionResult GetProperty(int propertyId) 
			if(propertyId <= 0)
			{
				return BadRequest();
			}

			return new JsonResult(_propertyRepository.GetProperty(propertyId));
		}

		[HttpPost("[action]")]

		/// <summary>
		/// Update property details
		/// </summary>
		/// <param name="FromBody"> Id: int, Type: PropertyType, Description: string, Rooms: int, Area: int, Washer: bool, Refigerator: bool, Iron: bool, AddressId: int, Address: Address, OwnerId: int, Owner: Owner} </param>
		public IActionResult UpdateProperty([FromBody] Property property)  

		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_propertyRepository.UpdateProperty(property);
			return new JsonResult(property.Id);
		}

		[HttpGet("[action]")]

		///<summary>
		/// Delete property
		/// </summary>
		public IActionResult DeleteProperty(int propertyId)   
		{
			if(propertyId <= 0)
			{
				return BadRequest();
			}

			var property = _propertyRepository.GetProperty(propertyId);
			if(property == null)
			{
				return NotFound("Cannot find property with provided propertyId");
			}

			var owner = _ownerRepository.GetOwner(property.OwnerId);
			if (owner == null)
			{
				return NotFound("Cannot find owner with provided ownerId.");
			}

			var address = _addressRepository.GetAddress(property.AddressId);
			if (address == null)
			{
				return NotFound("Cannot find address with provided addressId.");
			}

			_propertyRepository.DeleteProperty(property, address, owner);
			return new JsonResult(property.Id);
		}
	}
}