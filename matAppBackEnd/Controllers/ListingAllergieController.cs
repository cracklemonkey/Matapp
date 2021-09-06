using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ListingAllergiesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingAllergiesController : ControllerBase
    {
        private readonly ListingAllergieService _listingallergieService;

        public ListingAllergiesController(ListingAllergieService listingallergieService)
        {
            _listingallergieService = listingallergieService;
        }

        [HttpGet]
        public async Task <ActionResult<List<ListingAllergie>>> Get() =>
            await _listingallergieService.Get();

          

         [HttpGet("{listingallergieid}", Name = "GetListingAllergie")]
        public async Task <ActionResult<ListingAllergie>> Get(int listingallergieid)
        {   
            var listingallergie = await _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            return listingallergie;
        }
        


        [HttpPost]
        public async Task <ActionResult<ListingAllergie>> Create(ListingAllergie listingallergie)
        {
            await _listingallergieService.Create(listingallergie);

            return CreatedAtRoute("GetListingAllergie", new { listingallergieid = listingallergie.ListingAllergieId.ToString() }, listingallergie);
        }

        [HttpPut("{listingallergieid}")]
        public async Task <ActionResult<ListingAllergie>> Update(int listingallergieid, [FromBody] ListingAllergie listingallergieIn)
        {
            var listingallergie =  await _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            var updated = await _listingallergieService.UpdateListingAllergie(listingallergieid, listingallergieIn);

            return updated;

            
        }

        [HttpDelete("{listingallergieid}")]
        public async Task <ActionResult<ListingAllergie>> Delete(int listingallergieid)
        {
            var listingallergie = await _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            var deleted = await  _listingallergieService.Delete(listingallergie.ListingAllergieId);

            return deleted;

        }
        
        
    }

}