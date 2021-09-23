using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace OrderedListingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderedListingsController : ControllerBase
    {
        private readonly OrderedListingService _orderedlistingService;

        public OrderedListingsController(OrderedListingService orderedlistingService)
        {
            _orderedlistingService = orderedlistingService;
        }

        [HttpGet]
        public async Task <ActionResult<List<OrderedListing>>> Get() =>
            await _orderedlistingService.Get();

          

         [HttpGet("{listingid}", Name = "GetOrderedListing")]
        public async Task <ActionResult<OrderedListing>> Get(int listingid)
        {   
            var orderedlisting = await _orderedlistingService.Get(listingid);

            if (orderedlisting == null)
            {
                return NotFound();
            }

            return orderedlisting;
        }

    
          [HttpPost]
        public async Task <ActionResult<OrderedListing>> Create(OrderedListing orderedlisting)
        {
            await _orderedlistingService.Create(orderedlisting);

            return CreatedAtRoute("GetOrderedListing", new { listingid = orderedlisting.ListingId.ToString() }, orderedlisting);
        }

    

       

        [HttpPut("{listingid}")]
        public async Task <ActionResult<OrderedListing>> UpdateOrderedListing(int listingid, [FromBody] OrderedListing listingIn)
        {
            var listing = await _orderedlistingService.Get(listingid);

            if (listing == null)
            {
                return NotFound();
            };

            var updated = await _orderedlistingService.UpdateOrderedListing(listingid, listingIn);

            return updated;
        }


   

        [HttpDelete("{listingid}")]
        public async Task <ActionResult<OrderedListing>> Delete(int listingid)
        {
            var orderedlisting = await _orderedlistingService.Get(listingid);

            if (orderedlisting == null)
            {
                return NotFound();
            }

            var deleted = await _orderedlistingService.Delete(orderedlisting.ListingId);

            return deleted;

        }

        
    }

}