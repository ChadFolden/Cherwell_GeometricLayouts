using Cherwell_Geometry.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Cherwell_GeometryWebAPI.Tests
{
    [TestClass]
    public class Tables
    {
        private readonly short Rows = 6;
        private readonly short Cols = 6;
        private readonly short MaxRows = Table.MaxRows;

    #region Table_Instantiation

        [TestMethod]
        public void Table_InstatiateValidTriangle()
        {
            Int32 ExpectedTriangles = ((Rows * Cols) * 2);

            Table tbl = new Table(Rows, Cols);
            Assert.IsTrue(tbl.Triangles.Count == ExpectedTriangles);
        }

        [TestMethod]
        public void Table_InstatiateInvalidTriangle()
        {
            Rows = (Int16)(MaxRows + 2);

            try
            {
                Table tbl = new Table(Rows, Cols);
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(true);
            }
        }

    #endregion

    #region GetTriangleUsingKey

        [TestMethod]
        public void Table_GetTriangleUsingKey_ValidKey()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingKey("A1");
                Assert.IsTrue(A1.Coord1.X == 0 && A1.Coord1.Y == 0 &&
                            A1.Coord2.X == 0 && A1.Coord2.Y == 10 &&
                            A1.Coord3.X == 10 && A1.Coord3.Y == 10);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Table_GetTriangleUsingKey_KeyNotSupplied()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingKey(null);
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Table_GetTriangleUsingKey_InvalidStartingLetter()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingKey("111");
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Table_GetTriangleUsingKey_InvalidEndingNumber()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingKey("A1D1");
                Assert.IsTrue(false);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(true);
            }
        }

    #endregion

    #region GetUsingCoords

        [TestMethod]
        public void Table_GetTriangleUsingCoordinates_ValidCoords()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingCoordinates(new System.Drawing.Point(0, 0), new System.Drawing.Point(0, 10), new System.Drawing.Point(10, 10));
                Assert.IsTrue(A1.Key == "A1");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(false);
            }
        }

        [TestMethod]
        public void Table_GetTriangleUsingCoordinates_InValidCoords()
        {
            try
            {
                Table tbl = new Table(Rows, Cols);
                Triangle A1 = tbl.GetTriangleUsingCoordinates(new System.Drawing.Point(10, 10), new System.Drawing.Point(10,10), new System.Drawing.Point(10,10));
                Assert.IsTrue(A1.Key == null);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Assert.IsTrue(true);
            }
        }

        #endregion
    }
}
