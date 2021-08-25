using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Services
{
    public class ListingService
    {
        private readonly ListingDbContext _listings;

        public ListingService(ListingDbContext dbContext)
        {

            _listings = dbContext;
        }

        public List<Listing> Get(){
            return _listings.Listings.ToList();
        }
        public Listing Get(int id){
            var listing = _listings.Listings.Find(id);
            return listing;
        }
        public List<Listing> GetListingByUserId(int userid){
            
            return _listings.Listings.Where(x => x.UserId.Equals(userid)).ToList();
           
       } 
        public Listing Create(Listing listing)
        {   Console.WriteLine(listing);
            _listings.Listings.Add(listing);
            _listings.SaveChanges();
            return listing;
            
        }

        public void UpdateListing(int id, Listing listingIn){

             var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == id);

            entity.Title = listingIn.Title;
            entity.Description = listingIn.Description;
            entity.CreationDate = listingIn.CreationDate;
            entity.Deadline= listingIn.Deadline;
            entity.IsOpened = listingIn.IsOpened;
            entity.UserId = listingIn.UserId;
            
            _listings.Listings.Update(entity);
            _listings.SaveChanges();

            
        }

        public void Delete(Listing listingIn) {
              
            var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == listingIn.ListingId);
            
            
            _listings.Listings.Remove(entity);
            _listings.SaveChanges();
                

        }


        public void Delete(int id) {
        
        var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == id);


         _listings.Listings.Remove(entity);
         _listings.SaveChanges();
            

        }

}
}
