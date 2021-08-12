using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace matAppBackEnd.Models
{   
    public class Listing
    {
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }

    [BsonElement("title")]     
    public string Title {get; set;}

     [BsonElement("description")]     
    public string Description {get; set;}

    [BsonElement("creation_date")]     
    public DateTime CreationDate {get; set;}
    
    [BsonElement("deadline")]     
    public DateTime Deadline {get; set;}
    
    [BsonElement("opened")]     
    public DateTime Opened {get; set;}

    [BsonElement("expiration_date")]     
    public DateTime ExpirationDate {get; set;}

    [BsonElement("food_type")]     
    public List<string> FoodType {get; set;}

    [BsonElement("allergies")]     
    public List<string> Allergies {get; set;}

    [BsonElement("type_of_meal")]     
    public List<string> MealType {get; set;}

    [BsonElement("image")]     
    public string Image {get; set;}

    [BsonElement("user_owner")]     
    public string UserOwner {get; set;}




    




    }
}