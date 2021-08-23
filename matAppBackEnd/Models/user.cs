using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace matAppBackEnd.Models
{   
    public class User
    {

    public string Id { get; set; }

     
    public string Username {get; set;}

     
    public string Password {get; set;}

      
    public string EMail {get; set;}

     
    public string PhoneNumber {get; set;}

       
    public string Street {get; set;}

      
    public string City {get; set;}

      
    public string ZipCode {get; set;}

     
    public string Country {get; set;}






    }
}