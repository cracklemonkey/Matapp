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

                // Image test
                
                UserOwner = "a"
                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/listings",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Post_foodtype_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new FoodType
            {
                Name = "TestFoodType",

                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/foodtypes",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Post_Allergie_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new Allergie
            {
                Name = "TestAllergies",

                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/allergies",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Post_ListingFoodType_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new ListingFoodType
            {
                ListingId = 100,

                FoodTypeId = 100,

                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/listingfoodtypes",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task Post_ListingAllergie_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var body = new ListingAllergie
            {
                ListingId = 100,

                AllergieId = 100,

                
                
            };

            // act
            var httpResponse = await client.PostAsJsonAsync("api/listingallergies",body);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }



        
       
        

      
    }

}