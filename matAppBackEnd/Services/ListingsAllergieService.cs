using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace matAppBackEnd.Services
{
    public class ListingAllergieService
    {
        private readonly MatAppDbContext _listingallergies;

        public ListingAllergieService(MatAppDbContext dbContext)
        {

            _listingallergies = dbContext;
        }

        public async Task< List<ListingAllergie>> Get(){
            return _listingallergies.ListingAllergie.ToList();
        }
        public async Task <ListingAllergie> Get(int id){
            var listingallergie = _listingallergies.ListingAllergie.Find(id);
            return listingallergie;
        }
       
           
       
        public async Task <ListingAllergie> Create(ListingAllergie listingallergie)
        {   
            _listingallergies.ListingAllergie.Add(listingallergie);
            await _listingallergies.SaveChangesAsync();
            return listingallergie;
            
        }

        public async Task <ListingAllergie> UpdateListingAllergie(int id, ListingAllergie listingallergieIn){

             var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == id);

            entity.ListingId = listingallergieIn.ListingId;
            entity.AllergieId = listingallergieIn.AllergieId;
            
            _listingallergies.ListingAllergie.Update(entity);
            await _listingallergies.SaveChangesAsync();

            return entity;

            
        }

        public void Delete(ListingAllergie listingallergieIn) {
              
            var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == listingallergieIn.ListingAllergieId);
            
            
            _listingallergies.ListingAllergie.Remove(entity);
            _listingallergies.SaveChanges();
                

        }


        public async Task <ListingAllergie> Delete(int id) {
        
        var entity = _listingallergies.ListingAllergie.FirstOrDefault(x => x.ListingAllergieId == id);


         _listingallergies.ListingAllergie.Remove(entity);
         await _listingallergies.SaveChangesAsync();

         return entity;
            
        }
    }
}