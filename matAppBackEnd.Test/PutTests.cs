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
                Id = "111111111111111111111111",

                Title = "TestListing2",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                Opened = new DateTime(2021, 8, 14),

                ExpirationDate = new DateTime(2021, 9, 16),

                FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test

                UserOwner = "61139a2857720adc17f600cc"
            };
            var updateModel = new Listing
            {   
                Id = "111111111111111111111111",

                Title = "aaaa",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                Opened = new DateTime(2021, 8, 14),

                ExpirationDate = new DateTime(2021, 9, 16),

                FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test

                UserOwner = "61139a2857720adc17f600cc"
            };
            await client.PostAsJsonAsync("api/listings",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync("api/listings/111111111111111111111111",updateModel);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_Listings_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new Listing
            {   
                Id = "222211111111111111111111",

                Title = "TestListing2",

                Description = "asdasdasdasdas asd asd as as as dasd       asdasd  asd",

                CreationDate = new DateTime(2021, 8, 16),

                Deadline = new DateTime(2021, 9, 16),

                Opened = new DateTime(2021, 8, 14),

                ExpirationDate = new DateTime(2021, 9, 16),

                FoodType = new List<string>() { "Test", "Vegan", "C" },

                Allergies = new List<string>() { "Citrus", "Nuts", "Wheat" },

                MealType = new List<string>() { "Snacks", "Lunsj", "Dessert" },

                // Image test

                UserOwner = "61139a2857720adc17f600cc"
            };

                // act
            var httpResponse = await client.PutAsJsonAsync("api/listings/222211111111111111111111",createModel);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Put_Users_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new User
            {   
                Id = "111111111111111111111111",

                Username = "UserTest2",

                Password = "password",

                EMail = "aaa@bbb.com",

                PhoneNumber = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",
            };
            var updateModel = new User
            {   
                Id = "111111111111111111111111",

                Username = "aaaaaaa",

                Password = "password",

                EMail = "aaa@bbb.com",

                PhoneNumber = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",

                
            };
            await client.PostAsJsonAsync("api/users",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync("api/users/111111111111111111111111",updateModel);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]

        public async Task Put_Users_ShouldReturn_NotFound(){

             // arange
            var client = _factory.CreateClient();
            var createModel = new User
            {   
                Id = "222211111111111111111111",

                Username = "UserTest23",

                Password = "password",

                EMail = "aaa@bbb.com",

                PhoneNumber = "12345678",

                Street = "BesteGata 32D",

                City = "Oslo",

                ZipCode = "0000",

                Country = "Norway",
                
            };

                // act
            var httpResponse = await client.PutAsJsonAsync("api/Users/222211111111111111111111",createModel);

            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }


    }
}