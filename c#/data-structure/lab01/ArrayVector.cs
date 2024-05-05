using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public class ArrayVector
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
                if(index < 0 || index >= Length)
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

        public int SumPositivesFromChetIndex()
        {
            int saveSumm = 0;
            int counter = 0;
            for (int i = 1; i < coordinates.Length; i+=2)
            {
                if (coordinates[i] > 0)
                {
                    saveSumm += coordinates[i];
                    counter++;
                }
            }

            if (counter == 0)
            {
                throw new Exception("Не существует положительных, четных чисел по индексу!");
            }
            else
            {
                return saveSumm;
            }   
        }

        public int SumLessFromNechetIndex()
        {
            int moduleSum = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                moduleSum += Math.Abs(coordinates[i]);
            }

            double resultModuleSum = (double)moduleSum / coordinates.Length;

            int counter = 0;
            int saveSum = 0;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] < resultModuleSum)
                {
                    counter++;
                    saveSum += coordinates[i];
                }
            }

            if (counter == 0)
            {
                throw new Exception("Не существует положительных, четных чисел по индексу!");
            }
            else
            {
                return saveSum;
            }
        }

        public int MultChet()
        {
            int counter = 0;
            int multiplication = 1;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] > 0 && coordinates[i] % 2 == 0)
                {
                    counter++;
                    multiplication *= coordinates[i];
                }
            }

            if (counter == 0)
            {
                throw new Exception("Не существует положительных, четных чисел!");
            }
            else
            {
                return multiplication;
            }
        }

        public int MultNechet()
        {
            int counter = 0;
            int multiplication = 1;
            for (int i = 0; i < coordinates.Length; i++)
            {
                if (coordinates[i] < 0 && coordinates[i] % 3 != 0)
                {
                    counter++;
                    multiplication *= coordinates[i];
                }
            }

            if (counter == 0)
            {
                throw new Exception("Не существует положительных, четных чисел!");
            }
            else
            {
                return multiplication;
            }
        }

        public void SortUp()
        {
            int n = coordinates.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (coordinates[j] > coordinates[j + 1])
                    {
                        (coordinates[j], coordinates[j + 1]) = (coordinates[j + 1], coordinates[j]);
                    }
                }
            }
        }

        public void SortDown()
        {
            int n = coordinates.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (coordinates[j] < coordinates[j + 1])
                    {
                        (coordinates[j], coordinates[j + 1]) = (coordinates[j + 1], coordinates[j]);
                    }
                }
            }
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

    }
}
