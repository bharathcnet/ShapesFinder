using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShapeFinder.Services;

namespace ShapeFinder.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShapeController : ControllerBase
    {
        private readonly ILogger<ShapeController> _logger;

        public ShapeController(ILogger<ShapeController> logger)
        {
            _logger = logger;
            _logger.LogInformation("Application has started. Ready to take entries.");
        }

        [HttpPost]
        public void Entries(Dictionary<string, string> dimensions)
        {
            try
            {
                var service = new ShapeServices();
                foreach (var entry in dimensions)
                {
                    service.AddNew(new Rectangle()
                    {
                        Length = Convert.ToInt32(entry.Key),
                        Width = Convert.ToInt32(entry.Value)
                    });
                }
                _logger.LogInformation("New entries has been added.");
            }
            catch (Exception e)
            {
                _logger.LogWarning("Error occurred while creating new entries.");
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpGet]
        public string Get()
        {
            try
            {
                _logger.LogInformation("Getting all entries from the json file.");
                string response = null;
                var service = new ShapeServices();
                var result = service.GetAll();
                if (result.Count == 0)
                {
                    response += "No entries found";
                    _logger.LogInformation("No entries found. Start entering new.");
                    return response;
                }
                var percentage = service.SquarePercentage(result);

                response += $"Percentage of squares is {percentage}% \n\n\n";
                response += $"List of sorted rectangles \n";
                foreach (var x in result)
                {
                    var str = $"\n shape : {x.Shape} \n Length : {x.Length} \n Width : {x.Width} \n Area : {x.Area} \n Diagonal Length: {x.Diagonol} \n ";
                    response = response + str;
                }

                return response;
            }
            catch (Exception e)
            {
                _logger.LogWarning("Error occurred while getting all entries.");
                _logger.LogError(e.Message);
                throw;
            }
        }

        [HttpDelete]
        public bool DeleteEntries(int id)
        {                
            var service = new ShapeServices();
            var success = service.DeleteAllEntries();
            return success;
        }
    }
}
