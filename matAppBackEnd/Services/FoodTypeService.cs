using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Services
{
    public class FoodTypeService
    {
        private readonly MatAppDbContext _foodtypes;

        public FoodTypeService(MatAppDbContext dbContext)
        {

            _foodtypes = dbContext;
        }

        public async Task <List<FoodType>> Get(){
            return _foodtypes.FoodType.ToList();
        }
        public async Task <FoodType> Get(string name){
            var foodtype = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);
            return foodtype;
        }
    

        public async Task <List<FullFoodType>> GetFoodTypesByListingId(int id){
           
            var foodtypes =  _foodtypes.FullFoodType.FromSqlRaw($"select f.FoodTypeId, f.Name, lf.ListingFoodTypeId FROM [dbo].[FoodType] AS f JOIN [dbo].[ListingFoodType] AS lf ON f.FoodTypeId = lf.FoodTypeId JOIN [dbo].[Listings] AS l ON lf.ListingId = l.ListingId WHERE l.ListingId ={id}").ToList();
            
            return foodtypes;
       }
      

        public async Task <FoodType> Create(FoodType foodtype)
        {   
            _foodtypes.FoodType.Add(foodtype);
            await _foodtypes.SaveChangesAsync();
            return foodtype;
            
        }

        public async Task <FoodType> UpdateFoodType(string name, FoodType foodtypeIn){

             var entity = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);

            entity.Name = foodtypeIn.Name;
            
            _foodtypes.FoodType.Update(entity);
            await _foodtypes.SaveChangesAsync();

            return entity;

            
        }

        public void Delete(FoodType foodtypeIn) {
              
            var entity = _foodtypes.FoodType.FirstOrDefault(x => x.FoodTypeId == foodtypeIn.FoodTypeId);
            
            
            _foodtypes.FoodType.Remove(entity);
            _foodtypes.SaveChanges();
                

        }


        public async Task <FoodType> Delete(string name) {
        
        var entity = _foodtypes.FoodType.FirstOrDefault(x => x.Name == name);


         _foodtypes.FoodType.Remove(entity);
         await _foodtypes.SaveChangesAsync();

         return entity;
            
        }
    }
}