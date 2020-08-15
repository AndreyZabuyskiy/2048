using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class CopyIntArray
    {
        static public void Copy(int[,] destination, int[,] source)
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    destination[i, j] = source[i, j];
                }
            }
        }
    }
}
