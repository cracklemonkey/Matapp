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

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

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

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test
                */
                UserId = 2
            };
            await client.PostAsJsonAsync("api/listings",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync($"api/listings/{123}",updateModel);

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

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test
                */

                UserId = 2
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/listings/{2222}",createModel);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_Users_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new User
            {   
                

                Username = "UserTest2",

                Password = "password",

                Email = "aaa@bbb.com",

                Phone = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",
            };
            var updateModel = new User
            {   
                

                Username = "aaaaaaa",

                Password = "password",

                Email = "aaa@bbb.com",

                Phone = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",

                
            };
            await client.PostAsJsonAsync("api/users",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync($"api/users/{createModel.UserId}",updateModel);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_Users_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new User
            {   
                

                Username = "UserTest23",

                Password = "password",

                Email = "aaa@bbb.com",

                Phone = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync($"api/users/{2222}",createModel);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}