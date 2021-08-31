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
using Microsoft.EntityFrameworkCore;

namespace matAppBackEnd.Test.TestServer{
    public class PutTests{

        private readonly WebApplicationFactory<Startup> _factory;
        public PutTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task Put_Listings_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new Listing
            {   
                
                
                
                Title = "TestListing2",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                IsOpened = true,

               /* FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

            

                // Image test
                */

                UserId = 2
            };
            var updateModel = new Listing
            {   
                

                Title = "aaaa",

                Description = "asdfghkj",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                IsOpened = true,

               

               /* FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

              

                // Image test
                */
                UserId = 2
            };
            var response = await client.PostAsJsonAsync("api/listings",createModel);
            var created =  await response.Content.ReadAsAsync<Listing>();

            // act
            
            var httpResponse = await client.PutAsJsonAsync($"api/listings/{created.ListingId}",updateModel);
            
            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_Listings_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new Listing
            {   
                

                Title = "TestListing2",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                IsOpened = true,

                /* FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

               

                // Image test
                */

                UserId = 2
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/listings/{2222}",createModel);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

       

    }
}