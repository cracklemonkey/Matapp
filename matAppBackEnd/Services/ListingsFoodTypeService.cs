using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Services
{
    public class ListingFoodTypeService
    {
        private readonly ListingFoodTypeDbContext _listingfoodtypes;

        public ListingFoodTypeService(ListingFoodTypeDbContext dbContext)
        {

            _listingfoodtypes = dbContext;
        }

        public List<ListingFoodType> Get(){
            return _listingfoodtypes.ListingFoodType.ToList();
        }
        public ListingFoodType Get(int id){
            var listingfoodtype = _listingfoodtypes.ListingFoodType.Find(id);
            return listingfoodtype;
        }
       
           
       
        public ListingFoodType Create(ListingFoodType listingfoodtype)
        {   
            _listingfoodtypes.ListingFoodType.Add(listingfoodtype);
            _listingfoodtypes.SaveChanges();
            return listingfoodtype;
            
        }

        public void UpdateListingFoodType(int id, ListingFoodType listingfoodtypeIn){

             var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == id);

            entity.ListingId = listingfoodtypeIn.ListingId;
            entity.FoodTypeId = listingfoodtypeIn.FoodTypeId;
            
            _listingfoodtypes.ListingFoodType.Update(entity);
            _listingfoodtypes.SaveChanges();

            
        }

        public void Delete(ListingFoodType listingfoodtypeIn) {
              
            var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == listingfoodtypeIn.ListingFoodTypeId);
            
            
            _listingfoodtypes.ListingFoodType.Remove(entity);
            _listingfoodtypes.SaveChanges();
                

        }


        public void Delete(int id) {
        
        var entity = _listingfoodtypes.ListingFoodType.FirstOrDefault(x => x.ListingFoodTypeId == id);


         _listingfoodtypes.ListingFoodType.Remove(entity);
         _listingfoodtypes.SaveChanges();
            

        }
    }

}