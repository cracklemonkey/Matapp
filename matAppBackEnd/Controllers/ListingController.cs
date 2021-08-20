using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

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

         [HttpGet("{id}", Name = "GetListing")]
        public ActionResult<Listing> Get(string id)
        {   
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            return listing;
        }

        [HttpGet("userlistings/{userowner}", Name = "GetListingByUserOwner")]
        public ActionResult<List<Listing>> GetListingByUserOwner(string userowner) =>
            _listingService.GetListingByUserOwner(userowner);

        

        [HttpPost]
        public ActionResult<Listing> Create(Listing listing)
        {
            _listingService.Create(listing);

            return CreatedAtRoute("GetListing", new { id = listing.Id.ToString() }, listing);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Listing listingIn)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.Update(id, listingIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var listing = _listingService.Get(id);

            if (listing == null)
            {
                return NotFound();
            }

            _listingService.Remove(listing.Id);

            return NoContent();

        }

    }

}