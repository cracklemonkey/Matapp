using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace matAppBackEnd.Services
{
    public class AllergieService
    {
        private readonly MatAppDbContext _allergies;

        public AllergieService(MatAppDbContext dbContext)
        {

            _allergies = dbContext;
        }

        public async Task <List<Allergie>> Get(){
            return _allergies.Allergies.ToList();
        }
        public async Task <Allergie> Get(string name){
            var allergie = _allergies.Allergies.FirstOrDefault(x => x.Name == name);
            return allergie;
        }
       
           
       
        public async Task <Allergie> Create(Allergie allergie)
        {   
            _allergies.Allergies.Add(allergie);
            await _allergies.SaveChangesAsync();
            return allergie;
            
        }

        public async Task<Allergie> UpdateAllergie(string name, Allergie allergieIn){

             var entity = _allergies.Allergies.FirstOrDefault(x => x.Name == name);

            entity.Name = allergieIn.Name;
            
            _allergies.Allergies.Update(entity);
            await _allergies.SaveChangesAsync();

            return entity;
  
        }

        public void Delete(Allergie allergieIn) {
              
            var entity = _allergies.Allergies.FirstOrDefault(x => x.AllergieId == allergieIn.AllergieId);
            
            
            _allergies.Allergies.Remove(entity);
            _allergies.SaveChanges();
                

        }


        public async Task<Allergie> Delete(string name) {
        
        var entity = _allergies.Allergies.FirstOrDefault(x => x.Name == name);


         _allergies.Allergies.Remove(entity);
         await _allergies.SaveChangesAsync();

         return entity;
            
        }
    }
}