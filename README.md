# Cherwell_GeometricLayouts ###

This is a C# WebAPI with a javascript/jQuery HTML front end for the purpose of a pre-interview exercise at Cherwell Software.
For the simplest visual, download the code here and open the Cherwell_GeometryWebAPI/Cherwell_GeometryWebAPI.sln within Visual Studio 2017+ and then choose Debug->Start without Debugging.  

The [front end user interface](http://localhost:65224/index.html) should look like this: ![GUI](https://drive.google.com/file/d/1WA5WaBr43XvEuPhSOOQutRnyVqmM_-1U/view?usp=sharing)

 
### The Exercise
#### Geometric layouts
##### 1.A
The task, calculate the triangle coordinates for an image with right triangles such that for a given row (A-F) and column (1-12) you can produce any of the triangles in the layout below:

![Table](https://drive.google.com/file/d/1csU9_p4PZY7zG5bM5BXtoAKU8o7nQ4h3/view?usp=sharing)

![](https://drive.google.com/file/d/1DC7Gvq9A3nJJMhps85Y5oV0nKepsxZWz/view?usp=sharing)

While debugging, an example WebAPI URL reference could be: 
```html
http://localhost:65224/api/table/getusingkey/A2
```


##### 1.B
Lastly, given the vertex coordinates, calculate the row and column for the triangle:

![](https://drive.google.com/file/d/1JQigp_AzK60ou0jdl866GS3ScQGsmnn2/view?usp=sharing)

While debugging, an example WebAPI URL reference could be: 
```html
http://localhost:65224/api/table/GetUsingCoords/0/0/0/10/10/10
```

##### 1.C 
I added an GetAll to show the coordinates of all triangles: 

While debugging, an example WebAPI URL reference could be: 
```html
http://localhost:65224/api/table/GetAll
```
