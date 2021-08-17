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
        public async Task Put_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            var createModel = new Listing
            {
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
                Id = createModel.Id,

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
            await client.PostAsJsonAsync("api/person",createModel);


            // act
            var httpResponse = await client.PutAsJsonAsync("api/person/"+ createModel.Id,updateModel);

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }


    }
}