using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;

namespace ListingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingsController : ControllerBase
    {
        private readonly ListingService _listingService;

        public ListingsController(ListingService listingService)
        {
            _listingService = listingService;
        }

        [HttpGet]
        public ActionResult<List<Listing>> Get() =>
            _listingService.Get();

          

         [HttpGet("{listingid}", Name = "GetListing")]
        public ActionResult<Listing> Get(int listingid)
        {   
            var listing = _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            return listing;
        }
        
        [HttpGet("userlistings/{userowner}", Name = "GetListingByUserOwner")]

        public ActionResult<List<Listing>> GetListingByUserId(string userowner){
            var userIdList = _listingService.GetListingByUserId(userowner);

              
            bool isEmpty = !userIdList.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return userIdList;
        }
        [HttpGet("foodtypelistings/{id}", Name = "GetListingByFoodType")]
        public ActionResult<List<Listing>> GetListingByFoodType(int id){
            var List = _listingService.GetListingByFoodType(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

        [HttpGet("allergielistings/{id}", Name = "GetListingsThatDosentConatinAllergie")]
        public ActionResult<List<Listing>> GetListingsThatDosentConatinAllergie(int id){
            var List = _listingService.GetListingsThatDosentConatinAllergie(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }
        
        

        [HttpPost]
        public ActionResult<Listing> Create(Listing listing)
        {
            _listingService.Create(listing);

            return CreatedAtRoute("GetListing", new { listingid = listing.ListingId.ToString() }, listing);
        }

        [HttpPut("{listingid}")]
        public IActionResult Update(int listingid, [FromBody] Listing listingIn)
        {
            var listing = _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.UpdateListing(listingid, listingIn);

            return NoContent();
        }

        [HttpDelete("{listingid}")]
        public IActionResult Delete(int listingid)
        {
            var listing = _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.Delete(listing.ListingId);

            return NoContent();

        }
        
        
    }

}