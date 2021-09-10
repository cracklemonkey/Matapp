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
    public class ListingService
    {
        private readonly MatAppDbContext _listings;

        public ListingService(MatAppDbContext dbContext)
        {

            _listings = dbContext;
        }

        public async Task <List<Listing>>  Get(){
            return _listings.Listings.ToList();
        }
        public async Task <Listing> Get(int id){
            var listing = _listings.Listings.Find(id);
            return listing;
        }
        public async Task <List<Listing>> GetListingByUserId(string userid){
            
            return _listings.Listings.Where(x => x.UserOwner.Equals(userid)).ToList();
           
       } 

       public async Task <List<Listing>> GetListingByFoodType(int id){
           
            var list =  _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened, f.Name FROM dbo.Listings AS l JOIN dbo.ListingFoodType AS lf ON l.ListingId = lf.ListingId JOIN dbo.FoodType AS f ON lf.FoodTypeId = f.FoodTypeId WHERE f.FoodTypeId = {id}").ToList();
            
            return list;
       }

       public async Task <List<Listing>> GetListingsThatDosentConatinAllergie(int id){

            var templist = _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened FROM dbo.Listings AS l LEFT OUTER JOIN dbo.ListingAllergie AS la ON l.ListingId = la.ListingId LEFT OUTER JOIN dbo.Allergies AS a ON la.AllergieId = a.AllergieId WHERE ISNULL(a.AllergieId, 0) = {id}").ToList();
           
            bool IsEmpty = !templist.Any();

            if(IsEmpty){

                return templist;
            }           

            var list = _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened FROM dbo.Listings AS l LEFT OUTER JOIN dbo.ListingAllergie AS la ON l.ListingId = la.ListingId LEFT OUTER JOIN dbo.Allergies AS a ON la.AllergieId = a.AllergieId WHERE ISNULL(a.AllergieId, 0) != {id}").ToList();
            
            return list;
       }
        public async Task <Listing> Create(Listing listing)
        {   
            
            _listings.Listings.Add(listing);
            
            await _listings.SaveChangesAsync();
            
            return listing;
            
        }

         public async Task<Listing> CreateOrderedListing(int id, OrderedListing listingIn){

             var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == id);

            listingIn.ListingId = entity.ListingId;
            listingIn.Title = entity.Title;
            listingIn.Description = entity.Description;
            listingIn.CreationDate = entity.CreationDate;
            listingIn.Deadline = entity.Deadline;
            listingIn.IsOpened = entity.IsOpened ;
            listingIn.UserOwner = entity.UserOwner;
            listingIn.Image = entity.Image;

            _listings.OrderedListings.Add(listingIn);
            await _listings.SaveChangesAsync();

            _listings.Listings.Remove(entity);
            _listings.SaveChanges();
            
            return entity;

        }



        public async Task<Listing> UpdateListing(int id, Listing listingIn){

             var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == id);

            entity.Title = listingIn.Title;
            entity.Description = listingIn.Description;
            entity.CreationDate = listingIn.CreationDate;
            entity.Deadline= listingIn.Deadline;
            entity.IsOpened = listingIn.IsOpened;
            entity.UserOwner = listingIn.UserOwner;
            
            _listings.Listings.Update(entity);
            await _listings.SaveChangesAsync();
            
            return entity;

        }

        public void Delete(Listing listingIn) {
              
            var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == listingIn.ListingId);
            
            
            _listings.Listings.Remove(entity);
            _listings.SaveChanges();
                

        }


        public async Task<Listing> Delete(int id) {
        
        var entity = _listings.Listings.FirstOrDefault(x => x.ListingId == id);


         _listings.Listings.Remove(entity);
         await _listings.SaveChangesAsync();

         return entity;
            
        }
    }
}
