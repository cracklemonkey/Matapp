using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class Allergie
    
    {
        [Key]
        public int AllergieId {get; set;}

        public string Name {get; set;}




    }

}