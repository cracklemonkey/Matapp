using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Services
{
    public class ListingAllergieService
    {
        private readonly ListingAllergieDbContext _listingallergies;

        public ListingAllergieService(ListingAllergieDbContext dbContext)
        {

            _listingallergies = dbContext;
        }

        public List<ListingAllergie> Get(){
            return _listingallergies.ListingAllergie.ToList();
        }
        public ListingAllergie Get(int id){
            var listingallergie = _listingallergies.ListingAllergie.Find(id);
            return listingallergie;
        }
       
           
       
        public ListingAllergie Create(ListingAllergie listingallergie)
        {   
            _listingallergies.ListingAllergie.Add(listingallergie);
            _listingallergies.SaveChanges();
            return listingallergie;
            
        }

        public void UpdateListingAllergie(int id, ListingAllergie listingallergieIn){

             var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == id);

            entity.ListingId = listingallergieIn.ListingId;
            entity.AllergieId = listingallergieIn.AllergieId;
            
            _listingallergies.ListingAllergie.Update(entity);
            _listingallergies.SaveChanges();

            
        }

        public void Delete(ListingAllergie listingallergieIn) {
              
            var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == listingallergieIn.ListingAllergieId);
            
            
            _listingallergies.ListingAllergie.Remove(entity);
            _listingallergies.SaveChanges();
                

        }


        public void Delete(int id) {
        
        var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == id);


         _listingallergies.ListingAllergie.Remove(entity);
         _listingallergies.SaveChanges();
            

        }

}
}