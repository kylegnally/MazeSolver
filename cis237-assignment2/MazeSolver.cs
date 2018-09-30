﻿using System;
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
        private bool wroteAnO = false;
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public bool SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use MazeTraversal recursive call and solve the maze.
            MazeTraversal(maze, xStart, yStart);
            return true;
        }

        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: MazeTraversal(int row, int col)
        /// </summary>
        private void MazeTraversal(char[,] maze, int row, int col)
        {
            if (row < maze.GetLength(0) && col < maze.GetLength(1))
            {
                maze[row, col] = 'X';
                Console.Write(writer.WriteMaze(maze));
                System.Threading.Thread.Sleep(250);
                
                #region GoNorth
                // GoNorth
                if (maze[(row - 1), col] == '.')
                {
                    MazeTraversal(maze, row - 1, col);
                    //if (wroteAnO)
                    //{
                    //    Console.Write(writer.WriteMaze(maze));
                    //    wroteAnO = false;
                    //    System.Threading.Thread.Sleep(250);
                    //}
                }
                #endregion

                #region GoSouth
                if (maze[(row + 1), col] == '.')
                {
                    MazeTraversal(maze, row + 1, col);
                    //if (wroteAnO)
                    //{
                    //    Console.Write(writer.WriteMaze(maze));
                    //    wroteAnO = false;
                    //    System.Threading.Thread.Sleep(250);
                    //}
                }
                #endregion

                #region GoEast

                if (maze[row, (col + 1)] == '.')
                {
                    MazeTraversal(maze, row, col + 1);
                    //if (wroteAnO)
                    //{
                    //    Console.Write(writer.WriteMaze(maze));
                    //    wroteAnO = false;
                    //    System.Threading.Thread.Sleep(250);
                    //}
                }
                #endregion

                #region GoWest
                if (maze[row, (col - 1)] == '.')
                {
                    MazeTraversal(maze, row, col - 1);
                    //if (wroteAnO)
                    //{
                    //    Console.Write(writer.WriteMaze(maze));
                    //    wroteAnO = false;
                    //    System.Threading.Thread.Sleep(250);
                    //}
                }
                #endregion

                
            }
            // if nothing contains a ".", we can't go in any direction. Draw an "O"
            maze[row, col] = 'O';
            wroteAnO = true;
        }
    }
}
