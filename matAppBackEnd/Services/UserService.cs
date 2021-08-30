using matAppBackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System;

namespace matAppBackEnd.Services
{
    public class UserService
    {
        private readonly UserDbContext _users;

        public UserService(UserDbContext dbContext)
        {

            _users = dbContext;
        }

        public List<User> Get(){
            return _users.Users.ToList();
        }
        public User Get(int id){
            var user = _users.Users.Find(id);
            return user;
        }
      
        public User Create(User user)
        {   
            _users.Users.Add(user);
            _users.SaveChanges();
            return user;
            
        }

        public void UpdateUser(int id, User userIn){

             var entity = _users.Users.FirstOrDefault(x => x.UserId == id);

            entity.Username = userIn.Username;
            entity.Password = userIn.Password;
            entity.Email = userIn.Email;
            entity.Phone= userIn.Phone;
            entity.Street = userIn.Street;
            entity.City = userIn.City;
            entity.Country = userIn.Country;
            entity.ZipCode = userIn.ZipCode;
            
            
            _users.Users.Update(entity);
            _users.SaveChanges();

            
        }

        public void Delete(User userIn) {
              
            var entity = _users.Users.FirstOrDefault(x => x.UserId == userIn.UserId);
            
            
            _users.Users.Remove(entity);
            _users.SaveChanges();
                

        }


        public void Delete(int id) {
        
        var entity = _users.Users.FirstOrDefault(x => x.UserId == id);


         _users.Users.Remove(entity);
         _users.SaveChanges();
            

        }

}
}
