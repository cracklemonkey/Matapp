using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class FullFoodType
    
    {
        [Key]
        public int FoodTypeId {get; set;}
        public string Name {get; set;}
        public int ListingFoodTypeId {get; set;}
    }

}