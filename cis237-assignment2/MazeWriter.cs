using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment2
{
    /// <summary>
    /// Class to return a two-dimensional char array (char[,]) as a string. 
    /// </summary>
    class MazeWriter
    {
        private string _mazeAsString;

        public MazeWriter() { }

        /// <summary>
        /// Constructs and formats a two-dimensional char array (char[,]) as a simple string.
        /// </summary>
        /// <param name="arrayToDraw"></param>
        /// <returns>string</returns>
        public string WriteMaze(char[,] arrayToDraw)
        {
            _mazeAsString = "";

            for (int i = 0; i < arrayToDraw.GetLength(0); i++)
            {

                for (int j = 0; j < arrayToDraw.GetLength(1); j++)
                {
                    if (j >= arrayToDraw.GetLength(1)) continue;
                    _mazeAsString += arrayToDraw[i, j];
                    if (j != arrayToDraw.GetLength(1) - 1) continue;
                    _mazeAsString += "\n";
                }
            }

            _mazeAsString += "\n";

            return _mazeAsString;
        }
    }
}
