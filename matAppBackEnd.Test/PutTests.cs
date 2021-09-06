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
            

                // Image test
                

                UserOwner = "a"
            };
            var updateModel = new Listing
            {   
                

                Title = "aaaa",

                Description = "asdfghkj",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                IsOpened = true,

               
                // Image test
               
                UserOwner = "a"
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

        

                UserOwner = "a"
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/listings/{2222}",createModel);
                 // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_FoodType_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new FoodType
            {   
                
                Name = "TestFoodType2"
                
                
            };
            var updateModel =  new FoodType
            {   
                

                Name ="TestFoodType100"

               
               
            };
            var response = await client.PostAsJsonAsync("api/foodtypes",createModel);
            var created =  await response.Content.ReadAsAsync<FoodType>();

            // act
            
            var httpResponse = await client.PutAsJsonAsync($"api/foodtypes/{created.Name}",updateModel);
            
            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_FoodType_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new FoodType
            {   
                
                Name = "TestFoodType2"
                
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/foodtypes/{2222}",createModel);
                 // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_Allergie_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new Allergie
            {   
                
                Name = "TestAllergies2"
                
                
            };
            var updateModel =  new Allergie
            {   
                

                Name ="TestAllergies100"

               
               
            };
            var response = await client.PostAsJsonAsync("api/allergies",createModel);
            var created =  await response.Content.ReadAsAsync<Allergie>();

            // act
            
            var httpResponse = await client.PutAsJsonAsync($"api/allergies/{created.Name}",updateModel);
            
            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_Allergie_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new Allergie
            {   
                
                Name = "TestAllergie2"
                
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/allergies/{2222}",createModel);
             // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_ListingAllergie_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new ListingAllergie
            {   
                
                ListingId = 100,
                AllergieId = 100,
                
                
            };
            var updateModel =  new ListingAllergie
            {   
                

                ListingId = 110,
                AllergieId = 100,

               
               
            };
            var response = await client.PostAsJsonAsync("api/listingallergies",createModel);
            var created =  await response.Content.ReadAsAsync<ListingAllergie>();

            // act
            
            var httpResponse = await client.PutAsJsonAsync($"api/listingallergies/{created.ListingAllergieId}",updateModel);
            
            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_ListingAllergie_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new ListingAllergie
            {   
                
                ListingId = 110,
                AllergieId = 100,
                
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/listingallergies/{2222}",createModel);
                //assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_ListingFoodType_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new ListingFoodType
            {   
                
                ListingId = 100,
                FoodTypeId = 100,
                
                
            };
            var updateModel =  new ListingFoodType
            {   
                

                ListingId = 110,
                FoodTypeId = 100,

               
               
            };
            var response = await client.PostAsJsonAsync("api/listingfoodtypes",createModel);
            var created =  await response.Content.ReadAsAsync<ListingFoodType>();

            // act
            
            var httpResponse = await client.PutAsJsonAsync($"api/listingfoodtypes/{created.ListingFoodTypeId}",updateModel);
            
            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_ListingFoodType_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new ListingFoodType
            {   
                
                ListingId = 110,
                FoodTypeId = 100,
                
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/listingfoodtype/{2222}",createModel);
                //assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }



       

    }
}