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


namespace matAppBackEnd.Test {

    public class DeleteTest{

        private readonly WebApplicationFactory<Startup> _factory;
        public DeleteTest()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
            public async Task Delete_Listings_ShouldReturn_OKStatusCode(){
        // arange
            var client = _factory.CreateClient();
            var createModel = new Listing
            {   
                

                Title = "TestListing3",

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
             await client.PostAsJsonAsync("api/listings", createModel);

             // act
            var httpResponse = await client.DeleteAsync($"api/listings/{createModel.ListingId}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }
            [Fact]
            public async Task Delete_WithListingsNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/listings/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Delete_Users_ShouldReturn_OKStatusCode(){
        // arange
            var client = _factory.CreateClient();
            var createModel = new User
            {   
                

                Username = "UserTest3",

                Password = "password",

                Email = "aaa@bbb.com",

                Phone = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",
            };
             await client.PostAsJsonAsync("api/users", createModel);

             // act
            var httpResponse = await client.DeleteAsync($"api/users/{createModel.UserId}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }

            [Fact]
            public async Task Delete_WithUsersNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/users/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

    }



}