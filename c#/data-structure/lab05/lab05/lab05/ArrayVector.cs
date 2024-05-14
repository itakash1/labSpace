using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab04
{
    public class ArrayVector : IVectorable, IComparable
    {

        public int[] coordinates { get; set; }

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

        public int CompareTo(object? obj)
        {
            if (!(obj is IVectorable))
            {
                throw new Exception("Можно сравнить только объекты типа IVectorable");
            }
            IVectorable vec = (IVectorable)obj;
            if (vec.Length == this.Length)
            {
                return 0;
            } 
            else if (vec.Length > this.Length)
            {
                return -1;
            } 
            else
            {
                return 1;
            }
        }
        public override bool Equals(object? obj)
        {
            if (!(obj is IVectorable))
            {
                throw new Exception("Можно сравнивать только объекты типа IVectorable");
            }
            
            IVectorable vec = (IVectorable)obj;

            if (vec.Length != this.Length)
            {
                return false;
            }
            
            for (int i = 0; i < vec.Length; i++)
            {
                if (vec[i] != this[i])
                {
                    return false;
                }
            }
            
            return true;
        }

        public object Clone()
        {
            ArrayVector clone = new ArrayVector(Length);

            for (int i = 0; i < Length; i++)
            {
                clone[i] = this[i];
            }

            return clone;
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