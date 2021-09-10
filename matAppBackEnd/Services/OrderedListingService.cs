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
    public class OrderedListingService
    {
       private readonly MatAppDbContext _orderedlistings;

        public OrderedListingService(MatAppDbContext dbContext)
        {

            _orderedlistings = dbContext;
        }

        public async Task <List<OrderedListing>>  Get(){
            return _orderedlistings.OrderedListings.ToList();
        }

        public async Task <OrderedListing> Get(int id){
            var orderedlisting = _orderedlistings.OrderedListings.Find(id);
            return orderedlisting;
        }
       

             public async Task <OrderedListing> Create(OrderedListing orderedlisting)
        {   
            
            _orderedlistings.OrderedListings.Add(orderedlisting);
            
            await _orderedlistings.SaveChangesAsync();
            
            return orderedlisting;
            
        }

          public async Task<OrderedListing> CreateOrderedListing(int id, OrderedListing listingIn){

             var entity = _orderedlistings.Listings.FirstOrDefault(x => x.ListingId == id);

            listingIn.ListingId = entity.ListingId;
            listingIn.Title = entity.Title;
            listingIn.Description = entity.Description;
            listingIn.CreationDate = entity.CreationDate;
            listingIn.Deadline = entity.Deadline;
            listingIn.IsOpened = entity.IsOpened ;
            listingIn.UserOwner = entity.UserOwner;
            listingIn.Image = entity.Image;

            _orderedlistings.OrderedListings.Add(listingIn);
            await _orderedlistings.SaveChangesAsync();

            _orderedlistings.Listings.Remove(entity);
            _orderedlistings.SaveChanges();
            
            return listingIn;

        }


    public async Task<OrderedListing> UpdateOrderedListing(int id, OrderedListing listingIn){

             var entity =  _orderedlistings.OrderedListings.FirstOrDefault(x => x.ListingId == id);

            entity.Title = listingIn.Title;
            entity.Description = listingIn.Description;
            entity.CreationDate = listingIn.CreationDate;
            entity.Deadline= listingIn.Deadline;
            entity.IsOpened = listingIn.IsOpened;
            entity.UserOwner = listingIn.UserOwner;
            
             _orderedlistings.OrderedListings.Update(entity);
            await _orderedlistings.SaveChangesAsync();
            
            return entity;

        }


        public async Task<OrderedListing> Delete(int id) {
        
        var entity = _orderedlistings.OrderedListings.FirstOrDefault(x => x.ListingId == id);


         _orderedlistings.OrderedListings.Remove(entity);
         await _orderedlistings.SaveChangesAsync();

         return entity;
            

        }


}
}
