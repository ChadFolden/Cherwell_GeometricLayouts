using Cherwell_Geometry.Objects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Cherwell_GeometryWebAPI.Controllers
{
    public class TableController : ApiController
    {

        public Int16 Rows = 6;
        public Int16 Columns = 6;

        [HttpGet]
        [Route("api/Table/GetUsingKey/{KeyVal}")]
        /// <summary>
        /// Gets the triangle using the key value.
        /// </summary>
        /// <param name="KeyVal">The key value.</param>
        /// <returns>Triangle object</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">If Key value is not found</exception>
        public Triangle GetTriangleUsingKey(String KeyVal)
        {
            try
            {

                Cherwell_Geometry.Objects.Table TheTable = new Cherwell_Geometry.Objects.Table(Rows, Columns);
                TheTable.ValidateInput(KeyVal);

                Triangle TR = TheTable.GetTriangleUsingKey(KeyVal);

                if (TR != null)
                    return TR;
                else
                    throw new ArgumentOutOfRangeException();
            }
            catch (Exception ex)
            {
                String Msg = String.Format("Triangle with specified key ({0}) was not found.  Key is outside of range or not valid. ({1})", HttpUtility.HtmlEncode(KeyVal), ex.Message);
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(Msg), ReasonPhrase = Msg.Replace(".\r\n","_") };
                throw new HttpResponseException(resp);
            }
        }  

        [HttpGet]
        [Route("api/Table/GetUsingCoords/{P1X}/{P1Y}/{P2X}/{P2Y}/{P3X}/{P3Y}")]
        /// <summary>
        /// Gets the triangle using coordinates.
        /// </summary>
        /// <param name="P1X">The First Point X coordinate.</param>
        /// <param name="P1Y">The First Point Y coordinate.</param>
        /// <param name="P2X">The Second Point X coordinate.</param>
        /// <param name="P2Y">The Second Point Y coordinate.</param>
        /// <param name="P3X">The Third Point X coordinate.</param>
        /// <param name="P3Y">The Third Point Y coordinate.</param>
        /// <returns></returns>
        public Triangle GetTriangleUsingCoordinates(String P1X, String P1Y, String P2X, String P2Y, String P3X, String P3Y)
        {
            try
            {
                Cherwell_Geometry.Objects.Table TheTable = new Cherwell_Geometry.Objects.Table(Rows, Columns);
                Int16 X1 = 0; Int16 Y1 = 0;
                Int16 X2 = 0; Int16 Y2 = 0;
                Int16 X3 = 0; Int16 Y3 = 0;
                if (
                       Int16.TryParse(P1X, out X1) == false || Int16.TryParse(P1Y, out Y1) == false
                    || Int16.TryParse(P2X, out X2) == false || Int16.TryParse(P2Y, out Y2) == false
                    || Int16.TryParse(P3X, out X3) == false || Int16.TryParse(P3Y, out Y3) == false
                    )
                    throw new ArgumentOutOfRangeException("All Input must be valid integers less than 32,767");

                Point P1 = new Point(X1, Y1);
                Point P2 = new Point(X2, Y2);
                Point P3 = new Point(X3, Y3);

                Triangle Result = TheTable.GetTriangleUsingCoordinates(P1, P2, P3);

                if (Result.Key != null)
                    return Result;
                else
                    throw new ArgumentOutOfRangeException();
            }
            catch (Exception ex)
            {
                String Msg = String.Format("Triangle with specified coordinates was not found.  Coordinates are outside of range or not valid. ({0})", ex.Message);
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(Msg), ReasonPhrase = Msg.Replace(".\r\n", "_") };
                throw new HttpResponseException(resp);
            }
        }

        [HttpGet]
        [Route("api/Table/GetAll")]
        /// <summary>
        /// Gets a lsit of all triangles in the table.
        /// </summary>
        /// <returns>List of Triangles</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">There are 0 triangles.</exception>
        public List<Triangle> GetAllTriangles()
        {
            try
            {
                Cherwell_Geometry.Objects.Table TheTable = new Cherwell_Geometry.Objects.Table(Rows, Columns);

                if (TheTable.Triangles.Count >= 0)
                {
                    return TheTable.Triangles;
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            catch (Exception ex)
            {
                String Msg = String.Format("There were 0 triangles returned. ({0})", ex.Message);
                var resp = new HttpResponseMessage(HttpStatusCode.NotFound) { Content = new StringContent(Msg), ReasonPhrase = Msg.Replace(".\r\n", "_") };
                throw new HttpResponseException(resp);
            }
        }

    }
}
