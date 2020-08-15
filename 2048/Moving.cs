using System;
using System.Collections.Generic;
using System.Text;

namespace _2048
{
    abstract class Moving
    {
        protected int[,] Field = new int[4, 4];
        protected int score = 0;

        public int[,] Move(int[,] _Field, ref int _score)
        {
            CopyIntArray.Copy(Field, _Field);
            score = _score;

            CombineCommonElements();
            MoveRemainingElements();
            _score = score;

            return Field;
        }

        protected abstract void CombineCommonElements();
        protected abstract void MoveRemainingElements();
    }

    class MoveUp : Moving
    {
        protected override void CombineCommonElements()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (Field[j, i] != 0)
                    {
                        for (int k = j + 1; k < 4; ++k)
                        {
                            if (Field[j, i] == Field[k, i])
                            {
                                Field[j, i] *= 2;
                                Field[k, i] = 0;
                                score += Field[j, i];
                                break;
                            }
                            else if (Field[k, i] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        protected override void MoveRemainingElements()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 1; j < 4; ++j)
                {
                    if (Field[j, i] != 0)
                    {
                        for (int k = j; k > 0; --k)
                        {
                            if (Field[k - 1, i] == 0)
                            {
                                Field[k - 1, i] = Field[k, i];
                                Field[k, i] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
    class MoveRight : Moving
    {
        protected override void CombineCommonElements()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    if (Field[i, j] != 0)
                    {
                        for (int k = j + 1; k < 4; ++k)
                        {
                            if (Field[i, j] == Field[i, k])
                            {
                                Field[i, j] *= 2;
                                Field[i, k] = 0;
                                score += Field[i, j];
                                break;
                            }
                            else if (Field[i, k] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        protected override void MoveRemainingElements()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 2; j > -1; --j)
                {
                    if (Field[i, j] != 0)
                    {
                        for (int k = j; k < 3; ++k)
                        {
                            if (Field[i, k + 1] == 0)
                            {
                                Field[i, k + 1] = Field[i, k];
                                Field[i, k] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
    class MoveDown : Moving
    {
        protected override void CombineCommonElements()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 3; j > -1; --j)
                {
                    if (Field[j, i] != 0)
                    {
                        for (int k = j - 1; k > -1; --k)
                        {
                            if (Field[k, i] != 0)
                            {
                                if (Field[j, i] == Field[k, i])
                                {
                                    Field[j, i] *= 2;
                                    Field[k, i] = 0;
                                    score += Field[j, i];
                                    break;
                                }
                                else if (Field[k, i] != Field[j, i])
                                {
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        protected override void MoveRemainingElements()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 3; j > -1; --j)
                {
                    if (Field[j, i] != 0)
                    {
                        for (int k = j; k < 3; ++k)
                        {
                            if (Field[k, i] != 0)
                            {
                                if (Field[k + 1, i] == 0)
                                {
                                    Field[k + 1, i] = Field[k, i];
                                    Field[k, i] = 0;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    class MoveLeft : Moving
    {
        protected override void CombineCommonElements()
        {
            for (int i = 0; i < 4; ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (Field[i, j] != 0)
                    {
                        for (int k = j + 1; k < 4; ++k)
                        {
                            if (Field[i, j] == Field[i, k])
                            {
                                Field[i, j] *= 2;
                                Field[i, k] = 0;
                                score += Field[i, j];
                                break;
                            }
                            else if (Field[i, k] != 0)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }
        protected override void MoveRemainingElements()
        {
            for (int i = 0; i < Field.GetLength(0); ++i)
            {
                for (int j = 0; j < 4; ++j)
                {
                    if (Field[i, j] != 0)
                    {
                        for (int k = j; k > 0; --k)
                        {
                            if (Field[i, k - 1] == 0)
                            {
                                Field[i, k - 1] = Field[i, k];
                                Field[i, k] = 0;
                            }
                        }
                    }
                }
            }
        }
    }
}
