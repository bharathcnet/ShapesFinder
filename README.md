# ShapeFinder

## Task
The task is to create a small program that takes a number of rectangles as input. 
The program should then output the rectangles in sorted order with respect to the diagonal length. 
For each rectangle, it should return area and whether the rectangle is flat, tall or square. 
Finally, the program should output the total number of square rectangles as a percentage of the total number of rectangles.

Pay attention to the organization and completeness of your solution and include unit tests.

The solution must be coded in C#. as a rest service, with two end points one for supplying the rectangles and a 
second for getting the result of all supplied rectangles. 

1.      Rectangle is described in two dimensions: length and width

2.      Tall means width is bigger than length

3.      Square is square 

Please consider logging and storage of supplied rectangles.




## Url for browser

Get the shapes and stats of all entries
http://localhost:7630/shape


## PostMan requests

### To create a new entry of rectangle.
POST
http://localhost:7630/shape
body
{
    "45":"45",
    "33":"33"
}


### Get all the entries of rectangles and stats.
GET
http://localhost:7630/shape


### Clear all the entries of the json data file for a fresh start.
DELETE
http://localhost:7630/shape


## Data Storage

Json File in the project folder
../../RectangleEntries.json



