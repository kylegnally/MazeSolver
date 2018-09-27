using System;
using System.Runtime.InteropServices;

namespace cis237_assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// You might want to add other methods to help you out.
    /// A print maze method would be very useful, and probably neccessary to print the solution.
    /// If you are real ambitious, you could make a seperate class to handle that.
    /// </summary>
    class MazeSolver
    {
        string wentThisWay = "";
        private MazeWriter writer = new MazeWriter();
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.
            mazeTraversal(maze, xStart, yStart);
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        private void mazeTraversal(char[,] maze, int currentX, int currentY)
        {
            int xNow = currentX;
            int yNow = currentY;

            // draw the maze

            Console.Write(writer.WriteMaze(maze));

            Console.WriteLine("The current position is " + currentX.ToString() + ", " + currentY.ToString());
            Console.WriteLine("We went " + wentThisWay + "from where we were last turn.");
            

            // Did we reach an exit? (the only exit allowed should be the only case this is true)
            //if (maze.GetLength(0) == currentX + 1 || maze.GetLength(1) == currentY + 1)
            //{
            //    Console.Write("Solved!");
            //    return;
            //}

            // If what we see has a O in it, nope out
            //if (maze[currentX, currentY].ToString().Contains("O")) return;

            // GoWest
            if (maze[currentX, (currentY - 1)].ToString().Contains("."))
            {
                maze[currentX, (currentY - 1)] = char.Parse("X");
                currentY = (currentY - 1);
                wentThisWay = "west";
                mazeTraversal(maze, currentX, currentY);
            }

            // GoSouth
            if (maze[(currentX + 1), currentY].ToString().Contains("."))
            {
                maze[(currentX + 1), currentY] = char.Parse("X");
                currentX = (currentX + 1);
                wentThisWay = "south";
                mazeTraversal(maze, currentX, currentY);
            }

            // GoEast
            if (maze[currentX, (currentY + 1)].ToString().Contains("."))
            {
                maze[currentX, (currentY + 1)] = char.Parse("X");
                currentY = (currentY + 1);
                wentThisWay = "east";
                mazeTraversal(maze, currentX, currentY);
            }

            // GoNorth
            if (maze[(currentX - 1), currentY].ToString().Contains("."))
            {
                maze[(currentX - 1), currentY] = char.Parse("X");
                currentX = (currentX - 1);
                wentThisWay = "north";
                mazeTraversal(maze, currentX, currentY);
            }

            // if nothing contains a ".", we can't go in any direction. Draw an "O"
            maze[currentX, currentY] = char.Parse(("O"));

        }
    }
}
