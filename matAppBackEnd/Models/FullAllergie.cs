using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class FullAllergie
    
    {
        [Key]
        public int AllergieId {get; set;}
        public string Name {get; set;}
        public int ListingAllergieId {get; set;}
    }

}