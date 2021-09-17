using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;


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
        public async Task <ActionResult<List<Listing>>> Get() =>
            await _listingService.Get();

          

         [HttpGet("{listingid}", Name = "GetListing")]
        public async Task <ActionResult<Listing>> Get(int listingid)
        {   
            var listing = await _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            return listing;
        }
        
        [HttpGet("userlistings/{userowner}", Name = "GetListingByUserOwner")]

        public async Task <ActionResult<List<Listing>>> GetListingByUserId(string userowner){
            var userIdList = await _listingService.GetListingByUserId(userowner);

              
            bool isEmpty = !userIdList.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return userIdList;
        }

        [HttpGet("foodtypelistings/{id}", Name = "GetListingByFoodType")]
        public async Task<ActionResult<List<Listing>>> GetListingByFoodType(int id){
            var List = await _listingService.GetListingByFoodType(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

        [HttpGet("allergielistings/{id}", Name = "GetListingsThatDosentConatinAllergie")]
        public async Task <ActionResult<List<Listing>>> GetListingsThatDosentConatinAllergie(int id){
            var List = await _listingService.GetListingsThatDosentConatinAllergie(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }
        

  [HttpGet("getallcolumns", Name = "GetAllColumns")]
        public async Task<ActionResult<List<AllColumns>>> GetAllColumns(){
            var List = await _listingService.GetAllColumns();

            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

     [HttpGet("getallcolumns/foodtypeid/{id}", Name = "GetAllColumnsByFoodTypeId")]
        public async Task<ActionResult<List<AllColumns>>> GetAllColumnsByFoodTypeId(int id){
            var List = await _listingService.GetAllColumnsByFoodTypeId(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

    [HttpGet("getallcolumns/allergieid/{id}", Name = "GetAllColumnsByAllergieId")]
        public async Task<ActionResult<List<AllColumns>>> GetAllColumnsByAllergieId(int id){
            var List = await _listingService.GetAllColumnsByAllergieId(id);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }


    [HttpGet("getallcolumns/foodtypename/{foodname}", Name = "GetAllColumnsByFoodTypeName")]

        public async Task <ActionResult<List<AllColumns>>> GetAllColumnsByFoodTypeName(string foodname){
            var List = await _listingService.GetAllColumnsByFoodTypeName(foodname);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

  [HttpGet("getallcolumns/allergiename/{allergiename}", Name = "GetAllColumnsByAllergieName")]

        public async Task <ActionResult<List<AllColumns>>> GetAllColumnsByAllergieName(string allergiename){
            var List = await _listingService.GetAllColumnsByAllergieName(allergiename);

              
            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

        [HttpPost]
        public async Task <ActionResult<Listing>> Create(Listing listing)
        {
            await _listingService.Create(listing);

            return CreatedAtRoute("GetListing", new { listingid = listing.ListingId.ToString() }, listing);
        }


        [HttpPost("{listingid}")]
        public async Task <ActionResult<Listing>> CreateOrderedListing(int listingid, [FromBody] OrderedListing listingIn)
        {
            var listing = await _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            var orderedlisting = await _listingService.CreateOrderedListing(listingid, listingIn);

            return orderedlisting;
        }



        [HttpPut("{listingid}")]
        public async Task <ActionResult<Listing>> Update(int listingid, [FromBody] Listing listingIn)
        {
            var listing = await _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            var updated = await _listingService.UpdateListing(listingid, listingIn);

            return updated;
        }

        [HttpDelete("{listingid}")]
        public async Task <ActionResult<Listing>> Delete(int listingid)
        {
            var listing = await _listingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            }

            var deleted = await _listingService.Delete(listing.ListingId);

            return deleted;

        }
        
        
    }

}