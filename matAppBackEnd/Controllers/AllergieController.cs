using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task <ActionResult<List<Allergie>>> Get() =>
            await _allergieService.Get();

          

         [HttpGet("{name}", Name = "GetAllergiebyname")]
        public async Task <ActionResult<Allergie>> Get(string name)
        {   
            var allergie = await _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            return allergie;
        }

           [HttpGet("id/{id}", Name = "GetAllergie")]
        public async Task <ActionResult<Allergie>> Get(int id)
        {   
            var allergie = await _allergieService.Get(id);

            if (allergie == null)
            {
                return NotFound();
            }

            return allergie;
        }
        
        [HttpGet("allergiesbylistingid/{id}", Name = "GetAllergiesByListingId")]
        public async Task<ActionResult<List<FullAllergie>>> GetAllergiesByListingId(int id){
            var List = await _allergieService.GetAllergiesByListingId(id);

            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }



        [HttpPost]
        public async Task <ActionResult<Allergie>> Create(Allergie allergie)
        {
            await _allergieService.Create(allergie);

            return CreatedAtRoute("GetAllergie", new { name = allergie.Name.ToString() }, allergie);
        }

        [HttpPut("{name}")]
        public async Task <ActionResult<Allergie>> Update(string name, [FromBody] Allergie allergieIn)
        {
            var allergie = await _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            var updated = await _allergieService.UpdateAllergie(name, allergieIn);

            return updated;
        }

        [HttpDelete("{name}")]
        public async Task <ActionResult<Allergie>> Delete(string name)
        {
            var allergie = await _allergieService.Get(name);

            if (allergie == null)
            {
                return NotFound();
            }

            var deleted = await _allergieService.Delete(allergie.Name);

            return deleted;

        }
        
        
    }

}
