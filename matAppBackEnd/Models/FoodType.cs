using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{
    public class FoodType
    
    {
        [Key]
        public int FoodTypeId {get; set;}
        public string Name {get; set;}
    }

}