using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;

namespace CarListing.Test
{
    [TestClass]
    public class CarIntegrationTests
    {
        private readonly HttpClient _client;

        public CarIntegrationTests()
        {
            var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = server.CreateClient();
        }

        [TestMethod]
        public void CarGetAllTest()
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), "/api/cars/getallcars");

            //Act
            var response = _client.SendAsync(request).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        [DataRow(2)]
        public void CarGetSingleTest(int id)
        {
            //Arrange
            var request = new HttpRequestMessage(new HttpMethod("GET"), $"/api/cars/getsinglecar/{id}");

            //Act
            var response = _client.SendAsync(request).Result;

            //Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestMethod]
        public void CarPostTest()
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("POST"), $"/api/cars/addcar");

            // Act
            var response = _client.SendAsync(request).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [TestMethod]
        [DataRow(2)]
        public void CarPutTest(int id)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("PUT"), $"/api/cars/updatecar/{id}");

            // Act
            var response = _client.SendAsync(request).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.UnsupportedMediaType, response.StatusCode);
        }

        [TestMethod]
        [DataRow(1)]
        public void CarDeleteTest(int id)
        {
            // Arrange
            var request = new HttpRequestMessage(new HttpMethod("DELETE"), $"/api/cars/deletecar/{id}");

            // Act
            var response = _client.SendAsync(request).Result;

            // Assert
            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
