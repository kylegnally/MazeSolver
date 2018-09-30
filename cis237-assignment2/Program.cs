using System;

namespace cis237_assignment2
{
    class Program
    {
        /// <summary>
        /// This is the main entry point for the program.
        /// You are free to add anything else you would like to this program,
        /// however the maze solving part needs to occur in the MazeSolver class.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // Starting Coordinates.
            const int X_START = 1;
            const int Y_START = 1;

            ArrayTransposer transposer = new ArrayTransposer();

            // The first maze that needs to be solved.
            // Note: You may want to make a smaller version to test and debug with.
            // You don't have to, but it might make your life easier.
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
                System.Threading.Thread.Sleep(2000);
            }

            // Since we wrote into the maze, we have to unwrite it back to its initial state
            for (int row = 0; row < maze1.GetLength(0); row++)
            {
                for (int col = 0; col < maze1.GetLength(1); col++)
                {
                    if ((maze1[row, col] == 'O') || (maze1[row, col]) == 'X') maze1[row, col] = '.';
                }
            }

            // Create the second maze by transposing the first maze
            char[,] maze2 = TransposeMaze(transposer, maze1);
            if (mazeSolver.SolveMaze(maze2, X_START, Y_START))
            {
                Console.WriteLine("Maze 2 is solved!\n\nexiting program...");
                System.Threading.Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// This method will take in a 2 dimensional char array and return
        /// a char array maze that is flipped along the diagonal, or in mathematical
        /// terms, transposed.
        /// ie. if the array looks like 1, 2, 3
        ///                             4, 5, 6
        ///                             7, 8, 9
        /// The returned result will be:
        ///                             1, 4, 7
        ///                             2, 5, 8
        ///                             3, 6, 9
        /// The current return statement is just a placeholder so the program
        /// doesn't complain about no return value.
        /// 
        /// It is important that you return a "new" char array as the transposed maze.
        /// If you do not, you could end up only solving the transposed maze.
        /// </summary>
        /// <param name="mazeToTranspose"></param>
        /// <returns>transposedMaze</returns>
        static char[,] TransposeMaze(ArrayTransposer arrayToTranspose, char[,] mazeToTranspose)
        {
            //Write code her to create a transposed maze.
            return arrayToTranspose.TransposeArray(mazeToTranspose);
        }
    }
}
