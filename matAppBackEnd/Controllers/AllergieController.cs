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

          

         [HttpGet("{allergieid}", Name = "GetAllergie")]
        public ActionResult<Allergie> Get(int allergieid)
        {   
            var allergie = _allergieService.Get(allergieid);

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

            return CreatedAtRoute("GetAllergie", new { allergieid = allergie.AllergieId.ToString() }, allergie);
        }

        [HttpPut("{allergieid}")]
        public IActionResult Update(int allergieid, [FromBody] Allergie allergieIn)
        {
            var allergie = _allergieService.Get(allergieid);

            if (allergie == null)
            {
                return NotFound();
            }

            _allergieService.UpdateAllergie(allergieid, allergieIn);

            return NoContent();
        }

        [HttpDelete("{allergieid}")]
        public IActionResult Delete(int allergieid)
        {
            var allergie = _allergieService.Get(allergieid);

            if (allergie == null)
            {
                return NotFound();
            }

            _allergieService.Delete(allergie.AllergieId);

            return NoContent();

        }
        
        
    }

}