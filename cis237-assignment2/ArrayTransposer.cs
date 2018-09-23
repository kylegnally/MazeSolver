using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment2
{
    /// <summary>
    /// Class to transpose any two-dimensional array.
    /// </summary>
    class ArrayTransposer
    {
        static char[,] _transposedArray;

        /// <summary>
        /// Public method used to transpose a two-dimensional char array (char[,]). 
        /// </summary>
        /// <param name="original"></param>
        /// <returns>char[,]</returns>
        public char[,] TransposeArray(char[,] original)
        {
            _transposedArray = new char[original.GetLength(0), original.GetLength(1)];
            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    _transposedArray[i, j] = original[j, i];
                }
            }

            return _transposedArray;
        }
    }
}
