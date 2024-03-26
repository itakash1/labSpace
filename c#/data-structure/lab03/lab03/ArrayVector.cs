using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class ArrayVector : IVectorable
    {
        int[] coordinates;

        public ArrayVector(int lenght)
        {
            if (lenght < 0)
            {
                throw new Exception("Пространство не может быть меньше чем 0!");
            }
            else
            {
                coordinates = new int[lenght];
            }
        }

        public ArrayVector()
        {
            coordinates = new int[5];
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                {
                    throw new Exception("Индекс за границами массива!");
                }
                else
                {
                    return coordinates[index];
                }
            }
            set
            {
                if (index < 0 || index >= Length)
                {
                    throw new Exception("Индекс за границами массива!");
                }
                else
                {
                    coordinates[index] = value;
                }
            }
        }

        public int Length
        {
            get
            {
                return coordinates.Length;
            }
        }

        public double GetNorm()
        {
            double numbersSquared = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                numbersSquared += Math.Pow(coordinates[i], 2);
            }

            return Math.Sqrt(numbersSquared);
        }


        public void Log(string message = "")
        {
            if (message != "")
            {
                Console.Write(message + ": ");
            }
            Console.Write("{");
            for (int i = 0; i < Length; i++)
            {
                if (i == Length - 1)
                {
                    Console.Write(coordinates[i]);
                }
                else
                {
                    Console.Write(coordinates[i] + ", ");
                }
            }
            Console.WriteLine("}");
        }

        public static ArrayVector UserInput()
        {
            string inp;
            int length;

            do
            {
                Console.Write("Введите длину вектора: ");
            } while (!int.TryParse(Console.ReadLine(), out length) || length <= 0);

            ArrayVector vec = new ArrayVector(length);

            for (int i = 0; i < length; i++)
            {
                int value;
                do
                {
                    Console.Write($"Введите значение координаты {{{i + 1}}}: ");
                    inp = Console.ReadLine();
                } while (!int.TryParse(inp, out value));

                vec[i] = value;
            }
            return vec;
        }
        
        public override string ToString()
        {
            string result = Length.ToString() + ' ';
            for (int i = 0; i < Length; i++)
            {
                result = result + this[i].ToString() + ' ';
            }
            return result;
        }
    }
}