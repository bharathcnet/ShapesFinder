using ShapeFinder.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Castle.Core.Internal;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using ShapeFinder.Services;
using Xunit;
using Moq;
using Newtonsoft.Json;

namespace ShapeFinder.Test
{
    public class ShapeControllerTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        readonly HttpClient _client;

        public ShapeControllerTests(WebApplicationFactory<Startup> fixture)
        {
            _client = fixture.CreateClient();
        }

        [Fact]
        public async Task GET_retrieves_entries()
        { 
            // Arrange
            var response = await _client.GetAsync("/Shape");
            var result = await response.Content.ReadAsStringAsync();

            // Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.False(result.IsNullOrEmpty());
            Assert.True(response.IsSuccessStatusCode);
        }
    }
}
