using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace lab04
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
        
         public static void OutputVector(IVectorable vector, Stream stream)
            {
                BinaryWriter bw = new BinaryWriter(stream);
        
                bw.Write(vector.Length);
        
                for (int i = 0; i < vector.Length; i++)
                {
                    bw.Write(vector[i]);
                }
                bw.Close();
            }
            
            public static IVectorable InputVector(Stream stream)
            {
                BinaryReader br = new BinaryReader(stream);
        
                int length = br.ReadInt32();
        
                ArrayVector vector = new ArrayVector(length);
        
                for (int i = 0; i < vector.Length; i++)
                {
                    vector[i] = br.ReadInt32();
                }
                br.Close();
                return (IVectorable)vector;
            }
            public static void WriteVector(IVectorable vector, TextWriter print)
            {
                print.Write(vector);
                print.Close();
            }
            public static IVectorable ReadVector(TextReader reader)
            {
                string[] stringVector =  reader.ReadToEnd().Split(' ');
        
                ArrayVector vector = new ArrayVector(stringVector.Length - 1);
        
                try
                {
                    for (int i = 1; i < stringVector.Length; i++)
                    {
                        vector[i - 1] = int.Parse(stringVector[i]);
                    }
                }
                catch
                {
                    throw new FormatException("Ошибка, несуществующие значения");
                }
        
                reader.Close();
        
                return (IVectorable)vector;
            }
    }
}