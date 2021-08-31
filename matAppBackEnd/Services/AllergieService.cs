using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;
using Microsoft.AspNetCore.Mvc;

namespace matAppBackEnd.Services
{
    public class AllergieService
    {
        private readonly AllergieDbContext _allergies;

        public AllergieService(AllergieDbContext dbContext)
        {

            _allergies = dbContext;
        }

        public List<Allergie> Get(){
            return _allergies.Allergies.ToList();
        }
        public Allergie Get(int id){
            var allergie = _allergies.Allergies.Find(id);
            return allergie;
        }
       
           
       
        public Allergie Create(Allergie allergie)
        {   
            _allergies.Allergies.Add(allergie);
            _allergies.SaveChanges();
            return allergie;
            
        }

        public void UpdateAllergie(int id, Allergie allergieIn){

             var entity = _allergies.Allergies.FirstOrDefault(x => x.AllergieId == id);

            entity.Name = allergieIn.Name;
            
            _allergies.Allergies.Update(entity);
            _allergies.SaveChanges();

            
        }

        public void Delete(Allergie allergieIn) {
              
            var entity = _allergies.Allergies.FirstOrDefault(x => x.AllergieId == allergieIn.AllergieId);
            
            
            _allergies.Allergies.Remove(entity);
            _allergies.SaveChanges();
                

        }


        public void Delete(int id) {
        
        var entity = _allergies.Allergies.FirstOrDefault(x => x.AllergieId == id);


         _allergies.Allergies.Remove(entity);
         _allergies.SaveChanges();
            

        }

}
}