using System;

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
        /// <summary>
        /// This is the public method that will allow someone to use this class to solve the maze.
        /// Feel free to change the return type, or add more parameters if you like, but it can be done
        /// exactly as it is here without adding anything other than code in the body.
        /// </summary>
        public void SolveMaze(MazeWriter writer, char[,] maze, int xStart, int yStart)
        {
            // Do work needed to use mazeTraversal recursive call and solve the maze.

            // call MazeTraversal(coords) and start spinning our wheels
            // if we could go forward one space in any direction, we returned true
                // Write an X to that position in the array, invoke WriteMaze() from the MazeWriter class,
                // and recursively call SolveMaze again, passing it the new values
            // if we returned false, we back up and ... what? 
              
            // if we solved the maze
                //return true

            //else make a recursive call to this method using the current position as [xStart, yStart]
        }


        /// <summary>
        /// This should be the recursive method that gets called to solve the maze.
        /// Feel free to change the return type if you like, or pass in parameters that you might need.
        /// This is only a very small starting point.
        /// More than likely you will need to pass in at a minimum the current position
        /// in X and Y maze coordinates. EX: mazeTraversal(int currentX, int currentY)
        /// </summary>
        private void mazeTraversal()
        {
            // Implement maze traversal recursive call

            // the following calls aren't actual. This is pseudocode only. 
            // All four of these return a bool. Returning true re-calls SolveMaze with new coords <-- how???

            // GoNorth, etc are notated as methods but probably don't actually need to be methods

            // GoNorth(currentX, currentY) return true <-- Do the math for the coordinate calculations
            // GoSouth(same) etc
            // GoEast(same) etc
            // GoWest(same) etc

            // Write an O at the current position and invoke WriteMaze() from the MazeWriter class
            // return false

        }
    }
}
