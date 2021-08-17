using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace matAppBackEnd.Models
{   
    public class User
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("username")]     
    public string Username {get; set;}

    [BsonElement("password")]     
    public string Password {get; set;}

    [BsonElement("email")]     
    public string EMail {get; set;}

    [BsonElement("phonenumber")]     
    public string PhoneNumber {get; set;}

    [BsonElement("street")]     
    public string Street {get; set;}

    [BsonElement("city")]     
    public string City {get; set;}

    [BsonElement("zipcode")]     
    public string ZipCode {get; set;}

    [BsonElement("country")]     
    public string Country {get; set;}






    }
}