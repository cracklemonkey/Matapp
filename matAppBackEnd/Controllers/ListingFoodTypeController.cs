using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ListingFoodTypesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingFoodTypesController : ControllerBase
    {
        private readonly ListingFoodTypeService _listingfoodtypeService;

        public ListingFoodTypesController(ListingFoodTypeService listingfoodtypeService)
        {
            _listingfoodtypeService = listingfoodtypeService;
        }

        [HttpGet]
        public ActionResult<List<ListingFoodType>> Get() =>
            _listingfoodtypeService.Get();

          

         [HttpGet("{listingfoodtypeid}", Name = "GetListingFoodType")]
        public ActionResult<ListingFoodType> Get(int listingfoodtypeid)
        {   
            var listingfoodtype = _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            return listingfoodtype;
        }
        


        [HttpPost]
        public ActionResult<ListingFoodType> Create(ListingFoodType listingfoodtype)
        {
            _listingfoodtypeService.Create(listingfoodtype);

            return CreatedAtRoute("GetListingFoodType", new { listingfoodtypeid = listingfoodtype.ListingFoodTypeId.ToString() }, listingfoodtype);
        }

        [HttpPut("{listingfoodtypeid}")]
        public IActionResult Update(int listingfoodtypeid, [FromBody] ListingFoodType listingfoodtypeIn)
        {
            var listingfoodtype = _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            _listingfoodtypeService.UpdateListingFoodType(listingfoodtypeid, listingfoodtypeIn);

            return NoContent();
        }

        [HttpDelete("{listingfoodtypeid}")]
        public IActionResult Delete(int listingfoodtypeid)
        {
            var listingfoodtype = _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            _listingfoodtypeService.Delete(listingfoodtype.ListingFoodTypeId);

            return NoContent();

        }
        
        
    }

}