using Cherwell_Geometry.Objects;
using Cherwell_GeometryWebAPI.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Cherwell_GeometryWebAPI.Tests
{
    [TestClass]
    public class Cherwell_GeometryWebAPITests
    {

    #region GetUsingKey Tests

        [TestMethod]
        public void GetUsingKey_ValidKey()
        {
            TableController Ctrlr = new Controllers.TableController();
            Triangle A1 = Ctrlr.GetTriangleUsingKey("A1");

            Assert.IsTrue(A1.Coord1.X == 0 && A1.Coord1.Y == 0 && 
                            A1.Coord2.X == 0 && A1.Coord2.Y == 10 && 
                            A1.Coord3.X == 10 && A1.Coord3.Y == 10);
        }

        [TestMethod]
        public void GetUsingKey_KeyNotSupplied()
        {
            try
            {
                TableController Ctrlr = new Controllers.TableController();
                Triangle A1 = Ctrlr.GetTriangleUsingKey(null);
                Assert.IsTrue(false);
            }
            catch (HttpResponseException ex)
            {
                Assert.IsTrue(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        public void GetUsingKey_InvalidStartingLetter()
        {
            try
            {
                TableController Ctrlr = new Controllers.TableController();
                Triangle A1 = Ctrlr.GetTriangleUsingKey("111");
                Assert.IsTrue(false);
            }
            catch (HttpResponseException ex)
            {
                Assert.IsTrue(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        public void GetUsingKey_InvalidEndingNumber()
        {
            try
            {
                TableController Ctrlr = new Controllers.TableController();
                Triangle A1 = Ctrlr.GetTriangleUsingKey("A1D1");
                Assert.IsTrue(false);
            }
            catch (HttpResponseException ex)
            {
                Assert.IsTrue(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

    #endregion

    #region GetUsingCoords

        [TestMethod]
        public void GetUsingCoords_ValidCoords()
        {
            TableController Ctrlr = new Controllers.TableController();

            KeyValuePair<String, Triangle> A1 = Ctrlr.GetTriangleUsingCoordinates("0","0","0","10","10","10");

            Assert.IsTrue(A1.Key == "A1");
        }

        [TestMethod]
        public void GetUsingCoords_InValidCoords()
        {
            try
            {
                TableController Ctrlr = new Controllers.TableController();
                KeyValuePair<String, Triangle> A1 = Ctrlr.GetTriangleUsingCoordinates("A0", "B0", "C0", "D10", "E10", "F10");
                Assert.IsTrue(false);
            }
            catch (HttpResponseException ex)
            {
                Assert.IsTrue(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

        [TestMethod]
        public void GetUsingCoords_MissingCoords()
        {
            try
            {
                TableController Ctrlr = new Controllers.TableController();
                KeyValuePair<String, Triangle> A1 = Ctrlr.GetTriangleUsingCoordinates("0", "0", "0", "10", "10", null);
                Assert.IsTrue(false);
            }
            catch (HttpResponseException ex)
            {
                Assert.IsTrue(ex.Response.StatusCode == System.Net.HttpStatusCode.NotFound);
            }
        }

    #endregion

    #region GetAll

        [TestMethod]
        public void GetAll_ValidResponse()
        {
            TableController Ctrlr = new Controllers.TableController();

            List<KeyValuePair<String, Triangle>> All = Ctrlr.GetAllTriangles();

            Assert.IsTrue(All.Count == ((Ctrlr.Rows * Ctrlr.Columns) * 2));
        }

    #endregion

    }
}
