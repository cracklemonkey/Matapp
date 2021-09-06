using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
        public List<Listing> GetListingByUserId(string userid){
            
            return _listings.Listings.Where(x => x.UserOwner.Equals(userid)).ToList();
           
       } 

       public List<Listing> GetListingByFoodType(int id){
           
            var list = _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened FROM dbo.Listings AS l JOIN dbo.ListingFoodType AS lf ON l.ListingId = lf.ListingId JOIN dbo.FoodType AS f ON lf.FoodTypeId = f.FoodTypeId WHERE f.FoodTypeId = {id}").ToList();
            
            return list;
       }

       public List<Listing> GetListingsThatDosentConatinAllergie(int id){

            var templist = _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened FROM dbo.Listings AS l LEFT OUTER JOIN dbo.ListingAllergie AS la ON l.ListingId = la.ListingId LEFT OUTER JOIN dbo.Allergies AS a ON la.AllergieId = a.AllergieId WHERE ISNULL(a.AllergieId, 0) = {id}").ToList();
           
            bool IsEmpty = !templist.Any();

            if(IsEmpty){

                return templist;
            }           

            var list = _listings.Listings.FromSqlRaw($"SELECT l.ListingId, l.Title, l.Description, l.CreationDate, l.Deadline, l.UserOwner, l.Image, l.IsOpened FROM dbo.Listings AS l LEFT OUTER JOIN dbo.ListingAllergie AS la ON l.ListingId = la.ListingId LEFT OUTER JOIN dbo.Allergies AS a ON la.AllergieId = a.AllergieId WHERE ISNULL(a.AllergieId, 0) != {id}").ToList();
            
            return list;
       }
        public Listing Create(Listing listing)
        {   
            
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
            entity.UserOwner = listingIn.UserOwner;
            
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
