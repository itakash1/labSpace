using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public static class Vectors
    { 
        public static ArrayVector Sum(ArrayVector vectorFirst, ArrayVector vectorSecond)
        {
            if(vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Вектора разного размера!");
            }
            else
            {
                ArrayVector Sum = new ArrayVector(vectorFirst.Length);
                for (int i = 0; i < vectorFirst.Length; i++)
                {
                    Sum[i] = vectorFirst[i] + vectorSecond[i];
                }
                return Sum;
            }
        }

        public static double Scalar(ArrayVector vectorFirst, ArrayVector vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
            {
                throw new Exception("Вектора разного размера!");
            }
            else
            {
                double multi = 0;

                for (int i = 0; i < vectorFirst.Length; i++)
                {
                    multi += vectorFirst[i] * vectorSecond[i];
                }
                return multi;
            }
        }

        public static ArrayVector MultNumber(ArrayVector vector, int number)
        {
            ArrayVector multNum = new ArrayVector(vector.Length);
            for (int i = 0; i < vector.Length; i++)
            {
                multNum[i] = vector[i] * number;
            }
            return multNum;
        }

        public static double GetNormSt(ArrayVector vector)
        {
            return vector.GetNorm();
        }
    }
}
