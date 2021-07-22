using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using ShapeFinder.Controllers;
using ShapeFinder.Services;
using Xunit;

namespace ShapeFinder.Test
{
    public class ShapeFinderTests
    {
        private readonly Mock<ILogger<ShapeController>> _logger;

        private readonly ShapeController _controller;

        private readonly IShapeServices _service;

        public ShapeFinderTests()
        {
            _logger = new Mock<ILogger<ShapeController>>();
            _service = new ShapeServices();
            _controller = new ShapeController(_logger.Object);
        }

        /// <summary>
        /// Checks for a string response without any exception.
        /// </summary>
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var result = _controller.Get();

            // Assert
            Assert.IsType<string>(result);
        }

        /// <summary>
        /// Check if get method is getting all the entries.
        /// </summary>
        [Fact]
        public void Get_Should_Return_Expected_Entries()
        {
            // Act
            var entries = _service.GetAll();
            Assert.True(File.Exists(@"RectangleEntries.json"));

            // Assert
            Assert.True(entries.Count > 0);
        }

        /// <summary>
        /// Check if json data file exists in the directory.
        /// </summary>
        [Fact]
        public void Check_Data_File_Exists()
        {
            // Assert
            Assert.True(File.Exists(@"RectangleEntries.json"));
        }

        /// <summary>
        /// Check if the new entry exists in the data file.
        /// </summary>
        [Fact]
        public void Add_New_Entry_Test()
        {
            // Arrange
            var oldCount = _service.GetAll().Count;
            var rectangle = new Rectangle()
            {
                Length = 25,
                Width = 25
            };

            // Act
            var success = _service.AddNew(rectangle);

            // Assert
            Assert.True(success);
            Assert.Equal(oldCount + 1, _service.GetAll().Count);
        }
    }
}
