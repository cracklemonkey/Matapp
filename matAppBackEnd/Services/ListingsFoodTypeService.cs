using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace matAppBackEnd.Services
{
    public class ListingFoodTypeService
    {
        private readonly MatAppDbContext _listingfoodtypes;

        public ListingFoodTypeService(MatAppDbContext dbContext)
        {

            _listingfoodtypes = dbContext;
        }

        public async Task <List<ListingFoodType>> Get(){
            return _listingfoodtypes.ListingFoodType.ToList();
        }
        public async Task <ListingFoodType> Get(int id){
            var listingfoodtype = _listingfoodtypes.ListingFoodType.Find(id);
            return listingfoodtype;
        }
       
           
       
        public async Task <ListingFoodType> Create(ListingFoodType listingfoodtype)
        {   
            _listingfoodtypes.ListingFoodType.Add(listingfoodtype);
            await _listingfoodtypes.SaveChangesAsync();
            return listingfoodtype;
            
        }

        public async Task <ListingFoodType> UpdateListingFoodType(int id, ListingFoodType listingfoodtypeIn){

             var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == id);

            entity.ListingId = listingfoodtypeIn.ListingId;
            entity.FoodTypeId = listingfoodtypeIn.FoodTypeId;
            
            _listingfoodtypes.ListingFoodType.Update(entity);
            await _listingfoodtypes.SaveChangesAsync();

            return entity;

            
        }

        public void Delete(ListingFoodType listingfoodtypeIn) {
              
            var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == listingfoodtypeIn.ListingFoodTypeId);
            
            
            _listingfoodtypes.ListingFoodType.Remove(entity);
            _listingfoodtypes.SaveChanges();
                

        }


        public async Task <ListingFoodType> Delete(int id) {
        
        var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == id);


         _listingfoodtypes.ListingFoodType.Remove(entity);
         await _listingfoodtypes.SaveChangesAsync();

         return entity;

        }
    }
}