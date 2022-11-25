

# Pathfinding
 The basic appliction. Doesnt currently find the shortest possible path just finds a path. 
 ![](https://i.ibb.co/wYtXchx/Untitled.png)
 
 It's very basic with how it works - it takes the x and y coordinate of the start and simply subtracts them from the x and y coordinate of the end goal. By doing this it can calculate how many it needs to move across the x axis and how many times it needs to move across the y axis.
 
### Steps to making it better

 - By using the law of pythagoras we can assume that for any right-angled triangle that the hypotenuse is always shorter than the combination of the adjacent and opposite side. See below.
 -![pythagoras diagram](https://i.ibb.co/fS4PxgF/pythagoras.png)
- Because of this, we can diagonally draw a line of the path where it intersects the x line so that we make the path shorter.
![enter image description here](https://i.ibb.co/c67t9jj/pythagoras.png)
## How does it work?
To start with, we need to create a grid of tiles that the algorithm can move across. Each tile will be a way of moving and each tile can be connected to any adjacent tiles.
![enter image description here](https://i.ibb.co/rFYDN12/355-3553451-grid-clipart-empty-100-square-transparent-1-inch-grid.jpg)
As you can see above the green tiles are the tiles that the red can move. This will be the rules for our program.

To create the grid we will need to use a for loop. Each tile will be represented as a C# winforms panel. See below.![enter image description here](https://i.ibb.co/4T9P4NG/code-snippet.png)
