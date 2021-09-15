using System;
using System.ComponentModel.DataAnnotations;


namespace matAppBackEnd.Models
{   
    public class AllColumns
    {
    [Key]
    public int ListingId { get; set; }
    public string Title {get; set;}
    public string Description {get; set;}
    public DateTime CreationDate {get; set;}
    public DateTime Deadline {get; set;}
    public Boolean IsOpened {get; set;}    
    public string Image {get; set;}
    public string UserOwner {get; set;}
    public int ListingFoodTypeId {get; set;}
    public int FoodTypeId {get; set;}
    public int ListingAllergieId {get; set;}
    public int AllergieId {get; set;}
    public string AllergieName {get; set;}
    public string FoodTypeName {get; set;}
   
    
   

   




    }
}