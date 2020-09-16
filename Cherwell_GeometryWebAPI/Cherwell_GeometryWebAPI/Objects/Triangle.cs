using System;
using System.Drawing;

namespace Cherwell_Geometry.Objects
{
    /// <summary>
    /// Defines the attributes of a triangle
    /// </summary>
    public class Triangle
    {

    #region DECLARATIONS

        /// <summary>
        /// The two equal lengths of the right triangle
        /// </summary>
        public const Int16 RightTriangleLen = 10; //pixels

    #endregion

    #region PROPERTIES

        /// <summary>
        /// Gets the length of the triangle's hypotenuse.
        /// </summary>
        /// <value>
        /// The length of the triangle hypotenuse.
        /// </value>
        public Double TriangleHypotenuseLen
        {
            get
            {
                return Math.Sqrt(Math.Pow(RightTriangleLen, 2) + Math.Pow(RightTriangleLen, 2));
            }
        }
        /// <summary>
        /// Gets or sets the 1st coordinate.
        /// </summary>
        /// <value>
        /// The Coord1.
        /// </value>
        public Point Coord1 { get; set; }
        /// <summary>
        /// Gets or sets the 2nd coordinate.
        /// </summary>
        /// <value>
        /// The poiCoord2nt2.
        /// </value>
        public Point Coord2 { get; set; }
        /// <summary>
        /// Gets or sets the 3rd coordinate.
        /// </summary>
        /// <value>
        /// The Coord3.
        /// </value>
        public Point Coord3 { get; set; }
        /// <summary>
        /// Gets or sets the row number.
        /// </summary>
        /// <value>
        /// The rown number.
        /// </value>
        public Int32 RowNum { get; set; }
        /// <summary>
        /// Gets or sets the column number.
        /// </summary>
        /// <value>
        /// The column number.
        /// </value>
        public Int32 ColumnNum { get; set; }
        /// <summary>
        /// Gets or sets the key.
        /// </summary>
        /// <value>
        /// The key.
        /// </value>
        public String Key { get; set; }

    #endregion

    }
}
