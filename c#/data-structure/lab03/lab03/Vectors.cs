using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab03
{
    public static class Vectors
    {
        public static IVectorable Sum(IVectorable vectorFirst, IVectorable vectorSecond)
        {
            if (vectorFirst.Length != vectorSecond.Length)
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

        public static double Scalar(IVectorable vectorFirst, IVectorable vectorSecond)
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

        public static double GetNormSt(IVectorable vector)
        {
            return vector.GetNorm();
        }
    }
}