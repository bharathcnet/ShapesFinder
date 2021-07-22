using Microsoft.AspNetCore.Hosting.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ShapeFinder.Services
{
    public enum Shapes
    {
        Tall,
        Flat,
        Square,
        BadShape
    }

    public class ShapeServices : IShapeServices
    {
        /// <summary>
        /// calculates the percentage of squares out of total rectangles
        /// </summary>
        /// <param name="rectangles"></param>
        /// <returns></returns>
        public int SquarePercentage(List<Rectangle> rectangles)
        {
            var squares = rectangles.Count(x => x.Shape == Shapes.Square.ToString());
            var total = rectangles.Count();
            return (squares * 100)/ total;
        }

        /// <summary>
        /// Add a new entry of the rectangle
        /// </summary>
        /// <param name="rectangle"></param>
        public bool AddNew(Rectangle rectangle)
        {
            var success = false;
            var json = JsonConvert.SerializeObject(rectangle) + ",";
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"RectangleEntries.json", true))
            {
                file.WriteLine(json);
                success = true;
            }

            return success;
        }

        /// <summary>
        /// Get All the entries of the rectangles
        /// </summary>
        /// <returns></returns>
        public List<Rectangle> GetAll()
        {
            var result = new List<Rectangle>();
            using (StreamReader file = new StreamReader(@"RectangleEntries.json"))
            {
                var json = "[" + file.ReadToEnd() + "]";
                result = JsonConvert.DeserializeObject<List<Rectangle>>(json);
                file.Close();
            }
            result!.Sort();
            return result;
        }

        public bool DeleteAllEntries()
        {
            var success = false;
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"RectangleEntries.json", false))
            {
                file.Write(String.Empty);
                success = true;
            }
            return success;
        }
    }
}
