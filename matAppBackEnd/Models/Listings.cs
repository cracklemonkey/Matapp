using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace matAppBackEnd.Models
{   
    public class Listing
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




    




    }
}