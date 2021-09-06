using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task <ActionResult<List<ListingFoodType>>> Get() =>
            await _listingfoodtypeService.Get();

          

         [HttpGet("{listingfoodtypeid}", Name = "GetListingFoodType")]
        public async Task <ActionResult<ListingFoodType>> Get(int listingfoodtypeid)
        {   
            var listingfoodtype = await _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            return listingfoodtype;
        }
        


        [HttpPost]
        public async Task< ActionResult<ListingFoodType>> Create(ListingFoodType listingfoodtype)
        {
            await _listingfoodtypeService.Create(listingfoodtype);

            return CreatedAtRoute("GetListingFoodType", new { listingfoodtypeid = listingfoodtype.ListingFoodTypeId.ToString() }, listingfoodtype);
        }

        [HttpPut("{listingfoodtypeid}")]
        public async Task <ActionResult<ListingFoodType>> Update(int listingfoodtypeid, [FromBody] ListingFoodType listingfoodtypeIn)
        {
            var listingfoodtype = await _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            var updated = await _listingfoodtypeService.UpdateListingFoodType(listingfoodtypeid, listingfoodtypeIn);

            return updated;
        }

        [HttpDelete("{listingfoodtypeid}")]
        public async Task <ActionResult<ListingFoodType>> Delete(int listingfoodtypeid)
        {
            var listingfoodtype = await _listingfoodtypeService.Get(listingfoodtypeid);

            if (listingfoodtype == null)
            {
                return NotFound();
            }

            var deleted = await _listingfoodtypeService.Delete(listingfoodtype.ListingFoodTypeId);

            return deleted;

        }
        
        
    }

}