using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Services
{
    public class FoodTypeService
    {
        private readonly FoodTypeDbContext _foodtypes;

        public FoodTypeService(FoodTypeDbContext dbContext)
        {

            _foodtypes = dbContext;
        }

        public List<FoodType> Get(){
            return _foodtypes.FoodType.ToList();
        }
        public FoodType Get(string name){
            var foodtype = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);
            return foodtype;
        }
       
           
       
        public FoodType Create(FoodType foodtype)
        {   
            _foodtypes.FoodType.Add(foodtype);
            _foodtypes.SaveChanges();
            return foodtype;
            
        }

        public void UpdateFoodType(string name, FoodType foodtypeIn){

             var entity = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);

            entity.Name = foodtypeIn.Name;
            
            _foodtypes.FoodType.Update(entity);
            _foodtypes.SaveChanges();

            
        }

        public void Delete(FoodType foodtypeIn) {
              
            var entity = _foodtypes.FoodType.FirstOrDefault(x => x.FoodTypeId == foodtypeIn.FoodTypeId);
            
            
            _foodtypes.FoodType.Remove(entity);
            _foodtypes.SaveChanges();
                

        }


        public void Delete(string name) {
        
        var entity = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);


         _foodtypes.FoodType.Remove(entity);
         _foodtypes.SaveChanges();
            

        }

}
}