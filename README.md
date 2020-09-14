### Cherwell_GeometricLayouts ###

This is a C# WebAPI with a javascript/jQuery HTML front end for the purpose of a pre-interview exercise at Cherwell Software.
For the simplest visual, download the entire solution and open the Cherwell_GeometryWebAPI.sln within Visual Studio and then choose Debug->Start without Debugging

http://localhost:65224/index.html 

Geometric layouts
1.A
The task, calculate the triangle coordinates for an image with right triangles such that for a given row (A-F) and column (1-12) you can produce any of the triangles in the layout below:

http://localhost:65224/api/table/getusingkey/A2

1.B -
Lastly, given the vertex coordinates, calculate the row and column for the triangle:

http://localhost:65224/api/table/GetUsingCoords/0/0/0/10/10/10

1.C - I added an GetAll to show the coordinates of all triangles: 

http://localhost:65224/api/table/GetAll
