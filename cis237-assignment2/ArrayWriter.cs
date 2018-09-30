/// <summary>
/// Kyle Nally
/// CIS237 Assignment 2 - Solve a Maze using Recursion
/// 9/30/18
/// </summary>

namespace cis237_assignment2
{
    /// <summary>
    /// Class to return a two-dimensional char array (char[,]) as a string. 
    /// </summary>
    class ArrayWriter
    {
        private string _arrayAsString;

        /// <summary>
        /// Formats any two-dimensional char array (char[,]) as a simple string.
        /// </summary>
        /// <param name="arrayToDraw"></param>
        /// <returns>string</returns>
        public string WriteArray(char[,] arrayToDraw)
        {
            _arrayAsString = "";

            for (int i = 0; i < arrayToDraw.GetLength(0); i++)
            {

                for (int j = 0; j < arrayToDraw.GetLength(1); j++)
                {
                    if (j >= arrayToDraw.GetLength(1)) continue;
                    _arrayAsString += arrayToDraw[i, j];
                    if (j != arrayToDraw.GetLength(1) - 1) continue;
                    _arrayAsString += "\n";
                }
            }

            _arrayAsString += "\n";

            return _arrayAsString;
        }
    }
}
