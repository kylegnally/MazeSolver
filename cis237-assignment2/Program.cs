/// <summary>
/// Kyle Nally
/// CIS237 Assignment 2 - Solve a Maze using Recursion
/// 9/30/18
/// </summary>

using System;

namespace cis237_assignment2
{
    /// <summary>
    /// Main entry point. Main() lives here.
    /// </summary>
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// </summary>
        static void Main()
        {
            // Starting Coordinates.
            const int X_START = 1;
            const int Y_START = 1;

            ArrayTransposer transposer = new ArrayTransposer();

            // The first maze that needs to be solved.
            char[,] maze1 ={

            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' },
            { '#', '.', '.', '.', '#', '.', '.', '.', '.', '.', '.', '#' },
            { '#', '.', '#', '.', '#', '.', '#', '#', '#', '#', '.', '#' },
            { '#', '#', '#', '.', '#', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '#', '#', '#', '.', '#', '.', '.' },
            { '#', '#', '#', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '#', '.', '#', '.', '#', '.', '#', '.', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '.', '.', '#', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '.', '#', '#', '#', '.', '#' },
            { '#', '.', '.', '.', '.', '.', '.', '#', '.', '.', '.', '#' },
            { '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#', '#' }

        };

            // Create a new instance of a mazeSolver.
            MazeSolver mazeSolver = new MazeSolver();

            // Solve the original maze.
            if (mazeSolver.SolveMaze(maze1, X_START, Y_START))
            {
                Console.WriteLine("Maze 1 is solved!\n\nSolving Maze 2...");
                // Since we wrote into the maze to mark the positions,
                // we have to unwrite it back to its initial state
                MazeReset(maze1);
                System.Threading.Thread.Sleep(2000);
            }

            // Create the second maze by transposing the first maze
            char[,] maze2 = TransposeMaze(transposer, maze1);
            if (mazeSolver.SolveMaze(maze2, X_START, Y_START))
            {
                Console.WriteLine("Maze 2 is solved!\n\nexiting program...");
                System.Threading.Thread.Sleep(2000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Transposes a char[,].
        /// </summary>
        /// <param name="arrayToTranspose"></param>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] TransposeMaze(ArrayTransposer arrayToTranspose, char[,] mazeToTranspose)
        {
            return arrayToTranspose.TransposeArray(mazeToTranspose);
        }

        /// <summary>
        /// Method to reset the given maze to its initial unmarked state. Rewrites any
        /// 'X' or 'O' present to '.'. Does not alter maze structure. 
        /// </summary>
        /// <param name="maze"></param>
        static void MazeReset(char[,] maze)
        {
            for (int row = 0; row < maze.GetLength(0); row++)
            {
                for (int col = 0; col < maze.GetLength(1); col++)
                {
                    if ((maze[row, col] == 'O') || (maze[row, col]) == 'X') maze[row, col] = '.';
                }
            }
        }
    }
}
