/// <summary>
/// Kyle Nally
/// CIS237 Assignment 2 - Solve a Maze using Recursion
/// 9/30/18
/// </summary>

using System;

namespace cis237_assignment2
{
    /// <summary>
    /// This class is used for solving a char array maze.
    /// </summary>
    class MazeSolver
    {
        private ArrayWriter _writer = new ArrayWriter();
        private bool _wroteAnO;
        /// <summary>
        /// Public entry point for solving a maze given as a char[,].
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="xStart"></param>
        /// <param name="yStart"></param>
        /// <returns>bool</returns>
        public bool SolveMaze(char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use MazeTraversal recursive call and solve the maze.
            MazeTraversal(maze, xStart, yStart);
            return true;
        }

        /// <summary>
        /// Recursive method that traverses the maze given to it as a char[,]. 
        /// </summary>
        /// <param name="maze"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns>bool</returns>
        private bool MazeTraversal(char[,] maze, int row, int col)
        {
            // if we've solved the maze, draw an X at the end, draw the maze, and return true
            if (row + 1 == maze.GetLength(0) || col + 1 == maze.GetLength(1))
            {
                maze[row, col] = 'X';
                Console.Write(_writer.WriteArray(maze));
                return true;
            }

            // if the current row is less than the total rows and the current column
            // is less than the total columns, draw an X, print the maze, sleep, and
            // start testing directions
            if (row < maze.GetLength(0) && col < maze.GetLength(1))
            {
                maze[row, col] = 'X';
                Console.Write(_writer.WriteArray(maze));
                System.Threading.Thread.Sleep(200);
                
                #region GoNorth
                // if we're inside the maze and the space contains a '.'
                if (row > 0 && maze[(row - 1), col] == '.')
                {
                    // drop an 'X'
                    maze[row, col] = 'X';
                    // Check to see if we can go north by recursively calling MazeTraversal() using the
                    // "new" coordinates. If we can go north, this returns true. If it returns false,
                    // we will stop trying to go North (see final return statement at the end of
                    // MazeTraversal() for why this is important
                    if (MazeTraversal(maze, row - 1, col)) return true;
                }
                #endregion

                #region GoSouth
                if (row + 1 < maze.GetLength(0)  && maze[(row + 1), col] == '.')
                {
                    maze[row, col] = 'X';
                    // Check to see if we can go south by recursively calling MazeTraversal() using the
                    // "new" coordinates. If we can go south, this returns true. If it returns false,
                    // we will stop trying to go south (see final return statement at the end of
                    // MazeTraversal() for why this is important
                    if (MazeTraversal(maze, row + 1, col)) return true;
                }
                #endregion

                #region GoEast
                if (col + 1 < maze.GetLength(1) && maze[row, (col + 1)] == '.')
                {
                    maze[row, col] = 'X';
                    // Check to see if we can go east by recursively calling MazeTraversal() using the
                    // "new" coordinates. If we can go east, this returns true. If it returns false,
                    // we will stop trying to go east (see final return statement at the end of
                    // MazeTraversal() for why this is important
                    if (MazeTraversal(maze, row, col + 1)) return true;
                }
                #endregion

                #region GoWest
                if (col > 0 && maze[row, (col - 1)] == '.')
                {
                    maze[row, col] = 'X';
                    // Check to see if we can go west by recursively calling MazeTraversal() using the
                    // "new" coordinates. If we can go west, this returns true. If it returns false,
                    // we will stop trying to go west (see final return statement at the end of
                    // MazeTraversal() for why this is important
                    if (MazeTraversal(maze, row, col - 1)) return true;
                }
                #endregion

                // Did we write an O?
                if (_wroteAnO)
                {
                    // If so, write the maze!
                    Console.Write(_writer.WriteArray(maze));
                    // reset the flag
                    _wroteAnO = false;
                    // get lunch
                    System.Threading.Thread.Sleep(200);
                }

                // if nothing contains a ".", we can't go in any direction. Write an "O"
                maze[row, col] = 'O';
                // set the flag so we know we just wrote an O
                _wroteAnO = true;
            }
            // if the directions fail and we get here it means we can't "go" any further in a given direction.
            // At this point, control returns back to the call that failed (returned false)
            // and the rest of the code following that call executes (check if we wrote an O,
            // writing the maze to display that, resetting the flag to false, and taking a short nap).
            // Once we've reached the end of the maze, all of the methods left on the call stack will "unwind"
            // as each methos call on the stack resolves with the parameters it used at the time that particular
            // call was made.
            return false;
        }
    }
}
