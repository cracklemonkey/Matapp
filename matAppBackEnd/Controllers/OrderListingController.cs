using matAppBackEnd.Models;
using matAppBackEnd.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace OrderListingsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderListingsController : ControllerBase
    {
        private readonly OrderListingService _orderlistingService;

        public OrderListingsController(OrderListingService orderlistingService)
        {
            _orderlistingService = orderlistingService;
        }

        [HttpGet]
        public async Task <ActionResult<List<OrderListing>>> Get() =>
            await _orderlistingService.Get();

          

         [HttpGet("{orderid}", Name = "GetOrderListing")]
        public async Task <ActionResult<OrderListing>> Get(int orderid)
        {   
            var orderlisting = await _orderlistingService.Get(orderid);

            if (orderlisting == null)
            {
                return NotFound();
            }

            return orderlisting;
        }

         [HttpGet("userorders/{username}", Name = "GetOrderByUserName")]
        public async Task <ActionResult<List<OrderListing>>> Get(string username)
        {   
            var userNameOrderListing = await _orderlistingService.GetOrderByUserName(username);

              
            bool isEmpty = !userNameOrderListing.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return userNameOrderListing;
        }

 [HttpGet("fullorders", Name = "GetFullOrderListings")]
        public async Task<ActionResult<List<FullOrderListing>>> GetFullOrderListings(){
            var List = await _orderlistingService.GetFullOrderListings();

            bool isEmpty = !List.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return List;
        }

 [HttpGet("fullordersbyusername/{username}", Name = "GetFullOrdersByUserName")]
        public async Task <ActionResult<List<FullOrderListing>>> GetFullOrdersByUserName(string username)
        {   
            var list = await _orderlistingService.GetFullOrdersByUserName(username);

              
            bool isEmpty = !list.Any();
            if(isEmpty){

                return NotFound();
            }
            
            return list;
        }

[HttpGet("fullordersbyuserowner/{userowner}", Name = "GetFullOrdersByUserOwner")]
        public async Task <ActionResult<List<FullOrderListing>>> GetFullOrdersByUserOwner(string userowner)
        {   
            var list = await _orderlistingService.GetFullOrdersByUserOwner(userowner);

            bool isEmpty = !list.Any();
            if(isEmpty){

                return NotFound();
            }
            return list;
        }

          [HttpPost]
        public async Task <ActionResult<OrderListing>> Create(OrderListing orderlisting)
        {
            await _orderlistingService.Create(orderlisting);

            return CreatedAtRoute("GetOrderListing", new { orderid = orderlisting.OrderId.ToString() }, orderlisting);
        }


        [HttpPut("{listingid}")]
        public async Task <ActionResult<OrderListing>> UpdateOrderListing(int orderid, [FromBody] OrderListing listingIn)
        {
            var listing = await _orderlistingService.Get(orderid);

            if (listing == null)
            {
                return NotFound();
            }

            var updated = await _orderlistingService.UpdateOrderListing(orderid, listingIn);

            return updated;
        }
        

           [HttpDelete("{orderid}")]
        public async Task <ActionResult<OrderListing>> Delete(int orderid)
        {
            var orderlisting = await _orderlistingService.Get(orderid);

            if (orderlisting == null)
            {
                return NotFound();
            }

            var deleted = await _orderlistingService.Delete(orderlisting.OrderId);

            return deleted;

        }

        
    }

}