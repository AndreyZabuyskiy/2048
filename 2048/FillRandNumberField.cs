using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    class FillRandNumberField
    {
        public int[,] Field { get; set; }

        public int[,] Fill(int[,] field)
        {
            Field = field;

            if (IsExistZeroField())
            {
                int[] arr = ConvertFieldToOneArr();
                arr = FillRandom(arr);
                Field = ConvertOneArrToField(arr);
            }

            return Field;
        }

        private int[] ConvertFieldToOneArr()
        {
            int[] oneArr = new int[Field.GetLength(0) * Field.GetLength(1)];
            int idxOneArr = 0;

            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < Field.GetLength(1); ++j)
                {
                    oneArr[idxOneArr++] = Field[i, j];
                }
            }

            return oneArr;
        }

        private int[,] ConvertOneArrToField(int[] arr)
        {
            int idxOneArr = 0;

            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < Field.GetLength(1); ++j)
                {
                    Field[i, j] = arr[idxOneArr++];
                }
            }

            return Field;
        }

        private bool IsExistZeroField()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < Field.GetLength(1); ++j)
                {
                    if (Field[i, j] == 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private int[] FillRandom(int[] arr)
        {
            Random random = new Random();
            while (true)
            {
                int idx = random.Next(16);

                if (arr[idx] == 0)
                {
                    arr[idx] = 2;
                    break;
                }
            }

            return arr;
        }
    }
}
