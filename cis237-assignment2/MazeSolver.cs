using System;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;

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
        private bool solved = false;
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
        private bool MazeTraversal(char[,] maze, int row, int col)
        {
            // if we've solved the maze, draw an X at the end, draw the maze, and return true
            if (row + 1 == maze.GetLength(0) || col + 1 == maze.GetLength(1))
            {
                maze[row, col] = 'X';
                Console.Write(writer.WriteMaze(maze));
                return true;
            }

            // if the current row is less than the total rows and the current column
            // is less than the total columns, draw an X, print the maze, sleep, and
            // start testing directions
            if (row < maze.GetLength(0) && col < maze.GetLength(1))
            {
                maze[row, col] = 'X';
                Console.Write(writer.WriteMaze(maze));
                System.Threading.Thread.Sleep(250);
                
                #region GoNorth
                // if we're inside the maze and the space contains a '.'
                if (row > 0 && maze[(row - 1), col] == '.')
                {
                    // drop an 'X'
                    maze[row, col] = 'X';

                    if (MazeTraversal(maze, row - 1, col)) return true;
                    if (wroteAnO)
                    {
                        Console.Write(writer.WriteMaze(maze));
                        wroteAnO = false;
                        System.Threading.Thread.Sleep(250);
                    }
                }
                #endregion

                #region GoSouth
                if (row + 1 < maze.GetLength(0)  && maze[(row + 1), col] == '.')
                {
                    maze[row, col] = 'X';
                    if (MazeTraversal(maze, row + 1, col)) return true;
                    if (wroteAnO)
                    {
                        Console.Write(writer.WriteMaze(maze));
                        wroteAnO = false;
                        System.Threading.Thread.Sleep(250);
                    }
                }
                #endregion

                #region GoEast
                if (col + 1 < maze.GetLength(1) && maze[row, (col + 1)] == '.')
                {
                    maze[row, col] = 'X';
                    if (MazeTraversal(maze, row, col + 1)) return true;
                    if (wroteAnO)
                    {
                        Console.Write(writer.WriteMaze(maze));
                        wroteAnO = false;
                        System.Threading.Thread.Sleep(250);
                    }
                }
                #endregion

                #region GoWest
                if (col > 0 && maze[row, (col - 1)] == '.')
                {
                    maze[row, col] = 'X';
                    if (MazeTraversal(maze, row, col - 1)) return true;
                    if (wroteAnO)
                    {
                        Console.Write(writer.WriteMaze(maze));
                        wroteAnO = false;
                        System.Threading.Thread.Sleep(250);
                    }
                }
                #endregion

                // if nothing contains a ".", we can't go in any direction. Draw an "O"
                maze[row, col] = 'O';
                wroteAnO = true;
            }
            return false;
        }
    }
}
