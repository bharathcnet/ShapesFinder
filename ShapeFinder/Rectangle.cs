using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ShapeFinder.Services;

namespace ShapeFinder
{
    public class Rectangle : IComparable
    {
        public string Shape => GetShape().ToString();

        [Required]
        public int Length { get; set; }

        [Required]
        public int Width { get; set; }

        public int Area => Length * Width;

        public double Diagonol => Math.Sqrt((Length * Length) + (Width * Width));

        public Guid Id => Guid.NewGuid();

        public Shapes GetShape()
        {
            if (Length < Width)
                return Shapes.Tall;
            else if (Length > Width)
                return Shapes.Flat;
            else if (Length == Width)
                return Shapes.Square;
            else
                return Shapes.BadShape;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            Rectangle otherRectangle = obj as Rectangle;
            if (otherRectangle != null)
                return this.Diagonol.CompareTo(otherRectangle.Diagonol);
            else
                throw new ArgumentException("Object is not valid");
        }
    }
}
