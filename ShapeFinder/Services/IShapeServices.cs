using System.Collections.Generic;

namespace ShapeFinder.Services
{
    public interface IShapeServices
    {
        int SquarePercentage(List<Rectangle> rectangles);

        bool AddNew(Rectangle rectangle);

        List<Rectangle> GetAll();
    }
}