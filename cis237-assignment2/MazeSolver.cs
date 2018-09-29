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
        /// in X and Y maze coordinates. EX: mazeTraversal(int row, int col)
        /// </summary>
        private void mazeTraversal(char[,] maze, int row, int col)
        {

            maze[row, col] = 'X';
            Console.Write(writer.WriteMaze(maze));

            // Did we reach an exit? (the only exit allowed should be the only case this is true)
            if (maze.GetLength(0) == row + 1 || maze.GetLength(1) == col + 1)
            {
                Console.Write("Solved!");
                Environment.Exit(0);
            }

            // GoNorth
            if (maze[(row - 1), col] == '.')
            {
                row = (row - 1);
                mazeTraversal(maze, row, col);
            }

            // GoEast
            if (maze[row, (col + 1)] == '.')
            {
                col = (col + 1);
                mazeTraversal(maze, row, col);
            }

            // GoSouth
            if (maze[(row + 1), col] == '.')
            {
                row = (row + 1);
                mazeTraversal(maze, row, col);
            }

            // GoWest
            if (maze[row, (col - 1)] == '.')
            {
                col = (col - 1);
                mazeTraversal(maze, row, col);
            }

            // if nothing contains a ".", we can't go in any direction. Draw an "O"
            maze[row, col] = 'O';

        }
    }
}
