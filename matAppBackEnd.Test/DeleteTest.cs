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

            

                // Image test
                


                UserOwner = "aa"
            };
             var response = await client.PostAsJsonAsync("api/listings", createModel);
             var created =  await response.Content.ReadAsAsync<Listing>();

             // act
            var httpResponse = await client.DeleteAsync($"api/listings/{created.ListingId}");

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
            public async Task Delete_Allergie_ShouldReturn_OKStatusCode(){
            // arange
            var client = _factory.CreateClient();
            var createModel = new Allergie
            {   
                

                Name = "TestAllergie3",

              
            };
             var response = await client.PostAsJsonAsync("api/allergies", createModel);
             var created =  await response.Content.ReadAsAsync<Allergie>();

            // act
            var httpResponse = await client.DeleteAsync($"api/allergies/{created.Name}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }
            [Fact]
            public async Task Delete_WithAllergieNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/allergies/notaallergie");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Delete_FoodType_ShouldReturn_OKStatusCode(){
            // arange
            var client = _factory.CreateClient();
            var createModel = new FoodType
            {   
                

                Name = "TestFoodtype3",

              
            };
             var response = await client.PostAsJsonAsync("api/foodtypes", createModel);
             var created =  await response.Content.ReadAsAsync<FoodType>();

            // act
            var httpResponse = await client.DeleteAsync($"api/foodtypes/{created.Name}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }
            [Fact]
            public async Task Delete_WithFoodTypeNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/foodtypes/notafoodtype");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Delete_ListingAllergie_ShouldReturn_OKStatusCode(){
            // arange
            var client = _factory.CreateClient();
            var createModel = new ListingAllergie
            {   
                

                ListingId = 100,
                AllergieId = 100
              
            };
             var response = await client.PostAsJsonAsync("api/listingallergies", createModel);
             var created =  await response.Content.ReadAsAsync<ListingAllergie>();

            // act
            var httpResponse = await client.DeleteAsync($"api/listingallergies/{created.ListingAllergieId}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }
            [Fact]
            public async Task Delete_WithListingAllergieNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/listingallergies/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }

            [Fact]
            public async Task Delete_ListingFoodType_ShouldReturn_OKStatusCode(){
            // arange
            var client = _factory.CreateClient();
            var createModel = new ListingFoodType
            {   
                

                ListingId = 100,
                FoodTypeId = 100
              
            };
             var response = await client.PostAsJsonAsync("api/listingfoodtypes", createModel);
             var created =  await response.Content.ReadAsAsync<ListingFoodType>();

            // act
            var httpResponse = await client.DeleteAsync($"api/listingfoodtypes/{created.ListingFoodTypeId}");

            // assert
             httpResponse.IsSuccessStatusCode.Should().BeTrue();

            }
            [Fact]
            public async Task Delete_WithListingFoodTypeNotExists_ShouldReturn_NotFound()
            {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.DeleteAsync($"api/listingfoodtypes/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
            }


            

    }



}