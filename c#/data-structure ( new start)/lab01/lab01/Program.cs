using System.Diagnostics;

namespace lab01;

public static class Program
{
    public static void Main()
    {
        Hello();
        Console.WriteLine("Выберете класс для работы:\n" +
                          "1. ArrayVector\n" +
                          "3. Выход");
        string ask = Console.ReadLine();

        do
        {
            switch (ask)
            {
                case "1":
                    ArrayVectorTest();
                    break;
                case "3":
                    Console.WriteLine("Досвидание!");
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        } while (ask != "1" && ask != "3");
    }

    public static void ArrayVectorTest()
    {
        ArrayVector vector = ArrayVector.GetFromUserInput();
        vector.Log();
        while (true)
        {
            Console.WriteLine("Выберете действие из списка:\n" +
                              "\t1  - Посчитать сумму всех положительных элементов массива с четными номерами\n" +
                              "\t2  - Посчитать сумму элементов массива с нечетным индексом и одновременно меньше среднего значения всех модулей элементов массива\n" +
                              "\t3  - Сортировка по возрастанию\n" +
                              "\t4  - Сортировка по убыванию\n" +
                              "\t5  - Сумма векторов\n" +
                              "\t6  - Скалярное умножение\n" +
                              "\t7  - Умножить вектор на число\n" +
                              "\t8  - Посчитать модуль вектора\n" +
                              "\t9  - Перемножить все четные\n" +
                              "\t10 - Перемножить все нечетные, неделящиеся на 3\n" +
                              "\t11 - Установить элемент вектора\n" +
                              "\t0  - Выход из программы\n");
            string ask = Console.ReadLine();
            switch (ask)
            {
                case "1":
                    CountSumPositiveNumbersWithEvenIndex(vector);
                    break;
                case "2":
                    CountSumLessAverageAbsWithOddIndex(vector);
                    break;
                case "3":
                    vector.Log("До сортировки");
                    vector.SortUp();
                    vector.Log("После сортировки");
                    break;
                case "4":
                    vector.Log("До сортировки");
                    vector.SortDown();
                    vector.Log("После сортировки");
                    break;
                case "5":
                    SumVectors(vector);
                    break;
                case "6":
                    ScalarMultiply(vector);
                    break;
                case "7":
                    MultiplyVectorByNumber(vector);
                    break;
                case "8":
                    GetVectorNorm(vector);
                    break;
                case "9":
                    MultiplyEven(vector);
                    break;
                case "10":
                    MultiplyOdd(vector);
                    break;
                case "11":
                    SetVectorCoordinate(vector);
                    break;
                case "0":
                    Console.WriteLine("Доброго дня!");
                    break;
            }
        }
    }
    
    public static void CountSumPositiveNumbersWithEvenIndex(ArrayVector vector)
    {
        vector.Log("Созданный вектор");

        int sum = vector.SumPositivesFromChetIndex();

        if (sum == 0)
        {
            Console.WriteLine("В заданном векторе нет положительных элементов на четных позициях");
        }
        else
        {
            Console.WriteLine("Сумма положительных элементов с четными индексами: " + sum);
        }
    }
    
    public static void CountSumLessAverageAbsWithOddIndex(ArrayVector vector)
    {
        vector.Log("Созданный вектор");

        int sum = vector.SumLessFromNechetIndex();
        
        if (sum == 0)
        {
            Console.WriteLine("В заданном векторе нет значений на нечетных позициях, которые меньше среднего значения");
        }
        else
        {
            Console.WriteLine("Сумма элементов с нечетными индексами, которые меньше среднего значения всех модулей: " + sum);
        }
    }

    public static void SumVectors(ArrayVector vector)
    {
        ArrayVector vec2 = ArrayVector.GetFromUserInput();
        
        vector.Log("Первый вектор");
        vec2.Log("Второй вектор");

        try
        {
            ArrayVector result = Vectors.Sum(vector, vec2);
            result.Log("Результирующий векторсложения");
        }
        catch
        {
            Console.WriteLine("Длины векторов не совпадают");
        }
    }

    public static void ScalarMultiply(ArrayVector vector)
    {
        ArrayVector vec2 = new ArrayVector();
        
        vector.Log("Первый вектор");
        vec2.Log("Второй вектор");

        try
        {
            double result = Vectors.ScalarMultiply(vector, vec2);
            Console.WriteLine("Результат скалярного произведения: " + result);
        }
        catch
        {
            Console.WriteLine("Длины векторов не совпадают");
        }
    }

    public static void MultiplyVectorByNumber(ArrayVector vector)
    {
        vector.Log("Созданный вектор");
        
        int number;
        string inp;
        do
        {
            Console.Write("Введите число на которое умножить вектор: ");
            inp = Console.ReadLine();
        } while (!int.TryParse(inp, out number));

        ArrayVector result = Vectors.MultiplyByNumber(vector, number);
        
        result.Log("Результат умножения вектора на число");
    }

    public static void GetVectorNorm(ArrayVector vector)
    {
        vector.Log("Созданный вектор");
        
        Console.WriteLine($"Модуль созданного вектора: {vector.GetNorm():0.00}");
    }

    public static void MultiplyEven(ArrayVector vector)
    {
        vector.Log("Созданный вектор");
        
        int result = vector.MultChet();
        if (result == 0)
        {
            Console.WriteLine("В векторе нет положительных четных элементов");
        }
        else
        {
            Console.WriteLine($"Результат умножения всех четных положительных элементов по значению: {result}");
        }
    }
    
    public static void MultiplyOdd(ArrayVector vector)
    {
        vector.Log("Созданный вектор");

        int result = vector.MultNechet();
        if (result == 0)
        {
            Console.WriteLine("В векторе нет нечетных положительных элементов не делящихся на 3");
        }
        else
        {
            Console.WriteLine($"Результат умножения всех нечетных положительных элементов не делящихся на 3: {result}");
        }
    }
    
    public static void SetVectorCoordinate(ArrayVector vector)
    {
        vector.Log("Созданный вектор");

        int idx;
        string inp;
        do
        {
            Console.Write($"Введите номер координаты вектора для установки [1-{vector.Length}]: ");
            inp = Console.ReadLine();
        } while (!int.TryParse(inp, out idx) || idx < 1 || idx > vector.Length);

        int value;
        do
        {
            Console.Write($"Введите значение для {{{idx}}}: ");
            inp = Console.ReadLine();
        } while (!int.TryParse(inp, out value));

        vector[idx - 1] = value;
        
        vector.Log("Новый вектор");
    }
    
    public static void Greeting()
    {
        Console.WriteLine("Языки Программирования и Структуры Данных\n" +
                          "Лабораторная работа #1\n" +
                          "Выполнил студент группы 6101-020302D - Фадеев Артем");
    }
    public static void Hello()
    {
        Console.WriteLine("lab01 выполнил Маликов Николай Дмитриевич\n" +
                          "Студент группы 6104-020302");
    }
}