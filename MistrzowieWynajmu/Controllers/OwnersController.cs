using System;
using Microsoft.AspNetCore.Mvc;
using MistrzowieWynajmu.Models;
using MistrzowieWynajmu.Models.Interfaces;

namespace MistrzowieWynajmu.Controllers
{
    [Produces("application/json")]
    [Route("api/Owners")]
    public class OwnersController : Controller
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }

        [HttpPost("[action]")]
        public IActionResult AddOwner([FromBody] Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (string.IsNullOrEmpty(owner.Name) || string.IsNullOrEmpty(owner.Surname))
            {
                throw new Exception("Name and Surname can't be empty");
            }
            _ownerRepository.AddOwner(owner);
            return new JsonResult(owner);
        }
    }
}