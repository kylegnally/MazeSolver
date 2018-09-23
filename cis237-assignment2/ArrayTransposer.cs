using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237_assignment2
{
    class ArrayTransposer
    {
        static char[,] transposedArray;

        static ArrayTransposer()
        {
            
        }

        public char[,] TransposeArray(char[,] original)
        {
            transposedArray = new char[original.GetLength(0), original.GetLength(1)];
            for (int i = 0; i < original.GetLength(0); i++)
            {
                for (int j = 0; j < original.GetLength(1); j++)
                {
                    transposedArray[i, j] = original[j, i];
                }
            }

            return transposedArray;
        }
    }
}
