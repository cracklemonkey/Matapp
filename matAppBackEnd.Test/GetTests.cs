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
            var httpResponse = await client.GetAsync($"api/listingss/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetListing_WithUserOwner_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/listings/userlistings/6");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetListing_WithUserOwner_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/listings/userlistings/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task GetUser_OnRoot_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/users");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetUser_WithId_ShouldReturn_OKStatusCode()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync("api/users/2");

            // assert
            httpResponse.IsSuccessStatusCode.Should().BeTrue();
        }

         [Fact]
        public async Task GetUser_WithId_ShouldReturn_NotFound()
        {
            // arange
            var client = _factory.CreateClient();
            
            // act
            var httpResponse = await client.GetAsync($"api/users/{2222}");

            // assert
            httpResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}