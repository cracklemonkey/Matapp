using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace matAppBackEnd.Services
{
    public class OrderListingService
    {
       private readonly MatAppDbContext _orderlistings;

        public OrderListingService(MatAppDbContext dbContext)
        {

            _orderlistings = dbContext;
        }

        public async Task <List<OrderListing>>  Get(){
            return _orderlistings.OrderListings.ToList();
        }

        public async Task <OrderListing> Get(int id){
            var orderlisting = _orderlistings.OrderListings.Find(id);
            return orderlisting;
        }
       public async Task <List<OrderListing>> GetOrderByUserName(string username){
            
            return _orderlistings.OrderListings.Where(x => x.UserName.Equals(username)).ToList();
           
       }
     
        public async Task <OrderListing> Create(OrderListing orderlisting)
        {   
            
            _orderlistings.OrderListings.Add(orderlisting);
            
            await _orderlistings.SaveChangesAsync();
            
            return orderlisting;
            
        }


public async Task<OrderListing> UpdateOrderListing(int id, OrderListing listingIn){

             var entity =  _orderlistings.OrderListings.FirstOrDefault(x => x.OrderId == id);

            entity.UserName = listingIn.UserName;
            entity.OrderDate = listingIn.OrderDate;
            entity.ListingId = listingIn.ListingId;
            
             _orderlistings.OrderListings.Update(entity);
            await _orderlistings.SaveChangesAsync();
            
            return entity;

        }

        public async Task<OrderListing> Delete(int id) {
        
        var entity = _orderlistings.OrderListings.FirstOrDefault(x => x.OrderId == id);


         _orderlistings.OrderListings.Remove(entity);
         await _orderlistings.SaveChangesAsync();

         return entity;
            

        }


}
}
