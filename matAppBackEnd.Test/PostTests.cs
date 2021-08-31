using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using matAppBackEnd;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using matAppBackEnd.Models;
using System;
using System.Collections.Generic;

namespace matAppBackEnd.Test.TestServer
{
    public class PostTests 
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public PostTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Post_NewListing_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Listing
            {
                Title = "TestListing",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                IsOpened = true,


                /*FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test
                */
                UserId = 2
                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/listings",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

      
    }

}