using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class ListingAllergie
    
    {
        [Key]
        public int ListingAllergieId {get; set;}

        public int ListingId {get; set;}

        public int AllergieId {get; set;}




    }

}