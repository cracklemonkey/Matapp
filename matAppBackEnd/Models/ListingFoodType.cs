using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class ListingFoodType
    
    {
        [Key]
        public int ListingFoodTypeId {get; set;}

        public int ListingId {get; set;}

        public int FoodTypeId {get; set;}




    }

}