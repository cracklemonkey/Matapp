
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace matAppBackEnd.Models
{   
    public class User
    {
    [Key]
    public int UserId { get; set; }

     
    public string Username {get; set;}

     
    public string Password {get; set;}

      
    public string Email {get; set;}

     
    public string Phone {get; set;}

       
    public string Street {get; set;}

      
    public string City {get; set;}

      
    public string ZipCode {get; set;}

     
    public string Country {get; set;}






    }
}