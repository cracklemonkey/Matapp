using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

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
        public ActionResult<List<ListingAllergie>> Get() =>
            _listingallergieService.Get();

          

         [HttpGet("{listingallergieid}", Name = "GetListingAllergie")]
        public ActionResult<ListingAllergie> Get(int listingallergieid)
        {   
            var listingallergie = _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            return listingallergie;
        }
        


        [HttpPost]
        public ActionResult<ListingAllergie> Create(ListingAllergie listingallergie)
        {
            _listingallergieService.Create(listingallergie);

            return CreatedAtRoute("GetListingAllergie", new { listingallergieid = listingallergie.ListingAllergieId.ToString() }, listingallergie);
        }

        [HttpPut("{listingallergieid}")]
        public IActionResult Update(int listingallergieid, [FromBody] ListingAllergie listingallergieIn)
        {
            var listingallergie = _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            _listingallergieService.UpdateListingAllergie(listingallergieid, listingallergieIn);

            return NoContent();
        }

        [HttpDelete("{listingallergieid}")]
        public IActionResult Delete(int listingallergieid)
        {
            var listingallergie = _listingallergieService.Get(listingallergieid);

            if (listingallergie == null)
            {
                return NotFound();
            }

            _listingallergieService.Delete(listingallergie.ListingAllergieId);

            return NoContent();

        }
        
        
    }

}