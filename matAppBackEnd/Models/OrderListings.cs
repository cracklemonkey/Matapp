using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections;
using System.Collections.Generic;

namespace matAppBackEnd.Models
{   
    public class OrderListing
    {
    [Key]

    public int OrderId { get; set; }

    public string UserName {get; set;}

    public DateTime OrderDate {get; set;}

    public int ListingId { get; set; }

    }
}