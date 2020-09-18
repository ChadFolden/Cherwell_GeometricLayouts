using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;

namespace Cherwell_Geometry.Objects
{

    /// <summary>
    /// Defines a table of Triangles
    /// </summary>
    public class Table
    {

    #region DECLARTIONS

        /// <summary>
        /// The maximum number of rows
        /// </summary>
        /// <remarks>
        /// Do not extend past 26 (without code modifications) due to A-Z alpha limitations
        /// </remarks>
        public static Int16 MaxRows = 26;

        /// <summary>
        /// The list of triangles in this table
        /// </summary>
        public List<Triangle> Triangles;

    #endregion

    #region CTOR

        /// <summary>
        /// Initializes a new instance of the <see cref="Table"/> class.
        /// </summary>
        /// <param name="TotalRows">The total rows to build.</param>
        /// <param name="TotalColumns">The total columns to build.</param>
        /// <exception cref="ArgumentOutOfRangeException">Exception thrown when rows exceed acceptable range</exception>
        public Table(Int16 TotalRows, Int16 TotalColumns)
        {
            if (TotalRows > MaxRows)
                throw new ArgumentOutOfRangeException(String.Format("Invalid Number of rows ({0}).  Row count cannot exceed {1}", TotalRows, MaxRows));

            //Init list of triangles (NumRows X 2 triangles per column)
            Triangles = new List<Triangle>(TotalRows * (TotalColumns * 2));

            for (Int16 iRows = 0; iRows < TotalRows; iRows++)
            {
                for (Int16 jCols = 0; jCols < (TotalColumns * 2); jCols++)
                {
                    String Key = (Convert.ToChar(iRows + 65).ToString()) + (jCols + 1).ToString(); // Assign key value based off ascii char code and column
                    Triangle ThisTriangle = new Triangle();
                    ThisTriangle.Key = Key;
                    ThisTriangle.ColumnNum = 1 + Math.Abs(jCols / 2);                             // Assign column number by 'for' column .. plus 1 since is zero-based
                    ThisTriangle.RowNum = iRows + 1;                                              // Assign row number .. plus 1 since is zero-based
                    Int32 Coord1X = (Math.Abs(jCols / 2) * Triangle.RightTriangleLen);            // X coordinate = Triange height, every 2 columns
                    Int32 Coord1Y = (iRows * Triangle.RightTriangleLen);                          // Y coordinate = Triangle height X row
                    ThisTriangle.Coord1 = new Point(Coord1X, Coord1Y);
                    ThisTriangle.Coord3 = new Point(((ThisTriangle.ColumnNum) * Triangle.RightTriangleLen), ((iRows + 1) * Triangle.RightTriangleLen));

                    if (jCols % 2 == 0) //even numbered triangles
                    {
                        ThisTriangle.Coord2 = new Point(((ThisTriangle.ColumnNum - 1) * Triangle.RightTriangleLen), ((iRows + 1) * Triangle.RightTriangleLen));
                    }
                    else //odd numbered triangles
                    {
                        ThisTriangle.Coord2 = new Point(ThisTriangle.ColumnNum * Triangle.RightTriangleLen, iRows * Triangle.RightTriangleLen);
                    }

                    Triangles.Add(ThisTriangle);
                }
            }
        }

    #endregion

    #region METHODS        

        /// <summary>
        /// Gets the triangle matching the KEY value specified.
        /// </summary>
        /// <param name="Key">The key value to match.</param>
        /// <returns></returns>
        public Triangle GetTriangleUsingKey(String Key)
        {
            ValidateInput(Key);
            Triangle RetVal = null;
            foreach (Triangle TR in this.Triangles)
            {
                if (TR.Key.ToLower() == Key.ToLower())
                {
                    RetVal = TR;
                    break;
                }
            }

            return RetVal;
        }

        /// <summary>
        /// Gets the triangle using coordinates specified.
        /// </summary>
        /// <param name="Coord1">The coordinates 1.</param>
        /// <param name="Coord2">The coordinates 2.</param>
        /// <param name="Coord3">The coordinates 3.</param>
        /// <returns></returns>
        public Triangle GetTriangleUsingCoordinates(Point Coord1, Point Coord2, Point Coord3)
        {
            Triangle RetVal = new Triangle();
            foreach (Triangle TR in this.Triangles)
            {
                if (TR.Coord1 == Coord1 && TR.Coord2 == Coord2 && TR.Coord3 == Coord3)
                {
                    RetVal = TR;
                    break;
                }
            }

            return RetVal;
        }

        /// <summary>
        /// Validates the input.
        /// </summary>
        /// <param name="KeyVal">The key value.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// KeyVal not specified.
        /// or
        /// KeyVal must start with a letter.
        /// or
        /// KeyVal must start with a single letter and end with a valid integer number.
        /// or
        /// KeyVal must start with a single letter and end with a valid integer number.
        /// </exception>
        public void ValidateInput(String KeyVal)
        {
            //Check that KeyVal has a value
            if (KeyVal == null)
                throw new ArgumentOutOfRangeException("KeyVal not specified.");
            //Check that KeyVal starts with a single letter
            if (Char.IsLetter(KeyVal[0]) == false)
                throw new ArgumentOutOfRangeException("KeyVal must start with a letter.");
            //Check that KeyVal ends with a number
            Int32 TryParseInt = 0;
            if (Int32.TryParse(KeyVal.Substring(1, KeyVal.Length - 1), out TryParseInt) == false)
                throw new ArgumentOutOfRangeException("KeyVal must start with a single letter and end with a valid integer number.");
            //Check that KeyVal only contains letters and numbers
            Regex reg = new Regex(@"[^a-zA-Z0-9]");
            if (reg.IsMatch(KeyVal) == true)
                throw new ArgumentOutOfRangeException("KeyVal must start with a single letter and end with a valid integer number.");
        }

    #endregion

    }

}
