using Xunit;
using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using matAppBackEnd;
using Microsoft.AspNetCore.Mvc.Testing;

namespace BasicWebApi.Test.TestServer
{
    public class GetTests
    {
        private readonly WebApplicationFactory<Startup> _factory;
        public GetTests()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        [Fact]
        public async Task GetListings_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListing_WithId_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings/2");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListing_WithId_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listings/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListings_UserOwner_ShouldRetrun_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings/userlistings/asdasdasdasdaa");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }


        [Fact]
        public async Task GetListings_UserOwner_ShouldRetrun_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listings/userlistings/notauser");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListings_FoodType_ShouldRetrun_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings/foodtypelistings/1");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetListings_FoodType_ShouldRetrun_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listings/foodtypelistings/{2000}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListings_WithoutAllergies_ShouldRetrun_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings/allergielistings/2");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

        [Fact]
        public async Task GetListings_WitoutAllergies_ShouldRetrun_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listings/allergielistings/{2000}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetAllergies_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/allergies");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetAllergies_WithName_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/allergies/eggs");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetAllergies_WithName_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/allergies/notaallergie");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetFoodType_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/foodtypes");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetFoodType_WithName_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/foodtypes/breakfest");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetFoodType_WithName_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/foodtypess/notafoodtype");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListingFoodtype_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listingfoodtypes");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListingFoodtype_WithId_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listingfoodtypes/1");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListingFoodtype_WithId_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listingfoodtypes/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListingAllergies_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listingallergies");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListingAllergies_WithId_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listingallergies/1");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListingAllergies_WithId_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listingallergies/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }







        
    }
}