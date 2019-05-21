using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace CarListing.UnitTest
{
    public class CarIntegrationTests
    {
        private readonly HttpClient _client;

        public CarIntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [Fact] // Annotation of test with no parameters
        public void CarGetAllTest()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/cars/getallcars");

            //Act
            var response = _client.SendAsync(request).Result;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory] // Annotation of test w/ parameters
        [InlineData(2)]
        public void CarsGetSingleTest(int id)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/api/cars/getsinglecar/{id}");

            //Act
            var response = _client.SendAsync(request).Result;

            //Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
