using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace AllergiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergiesController : ControllerBase
    {
        private readonly AllergieService _allergieService;

        public AllergiesController(AllergieService allergieService)
        {
            _allergieService = allergieService;
        }

        [HttpGet]
        public ActionResult<List<Allergie>> Get() =>
            _allergieService.Get();

          

         [HttpGet("{name}", Name = "GetAllergie")]
        public ActionResult<Allergie> Get(string name)
        {   
            var allergie = _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            return allergie;
        }
        


        [HttpPost]
        public ActionResult<Allergie> Create(Allergie allergie)
        {
            _allergieService.Create(allergie);

            return CreatedAtRoute("GetAllergie", new { name = allergie.Name.ToString() }, allergie);
        }

        [HttpPut("{name}")]
        public IActionResult Update(string name, [FromBody] Allergie allergieIn)
        {
            var allergie = _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            _allergieService.UpdateAllergie(name, allergieIn);

            return NoContent();
        }

        [HttpDelete("{name}")]
        public IActionResult Delete(string name)
        {
            var allergie = _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            _allergieService.Delete(allergie.Name);

            return NoContent();

        }
        
        
    }

}