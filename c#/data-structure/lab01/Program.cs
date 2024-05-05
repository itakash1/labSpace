using lab01;
using System;

class Programm
{
    public static void Main()
    {
        Console.WriteLine("Лабораторная работа N1. Выполнил студент группы 6104-020302D, Маликов Николай Дмитриевич");

        Console.WriteLine("Введите размерность пространства первого вектора: ");
        int vFirstLgth = int.Parse(Console.ReadLine());

        Console.WriteLine("Введите размерность пространства второго вектора: ");
        int vSecondLgth = int.Parse(Console.ReadLine());

        ArrayVector arrayVector1 = new ArrayVector(vFirstLgth);
        ArrayVector arrayVector2 = new ArrayVector(vSecondLgth);

        Console.WriteLine("Ввидете первый вектор: ");
        for (int i = 0; i < vFirstLgth; i++)
        {
            Console.WriteLine("Введите число: ");
            arrayVector1[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Введите второй вектор: ");
        for (int i = 0; i < vSecondLgth; i++)
        {
            Console.WriteLine("Введите число: ");
            arrayVector2[i] = int.Parse(Console.ReadLine());
        }

        arrayVector1.Log("Первый вектор");
        arrayVector2.Log("Второй вектор");
        Console.WriteLine($"Информация о векторах:\nПервый вектор: ");
        Console.WriteLine($"Длина вектора: {arrayVector1.GetNorm()}");
        try
        {
            Console.WriteLine($"Сумма положительных с четными номерами координат: {arrayVector1.SumPositivesFromChetIndex()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Сумма с нечетными номерами вектора, которые меньше ср. знач. модулей координат: {arrayVector1.SumLessFromNechetIndex()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Прозведение положительных четных координат: {arrayVector1.MultChet()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Прозведение нечетных и не делящихся нацело на 3 координат: {arrayVector1.MultNechet()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        arrayVector1.SortUp();
        arrayVector1.Log("Сортировка по возрастанию");
        arrayVector1.SortDown();
        arrayVector1.Log("Сортировка по убыванию");

        Console.WriteLine($"Информация о векторах:\nВторой вектор: ");
        Console.WriteLine($"Длина вектора: {arrayVector2.GetNorm()}");
        try
        {
            Console.WriteLine($"Сумма положительных с четными номерами координат: {arrayVector2.SumPositivesFromChetIndex()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Сумма с нечетными номерами вектора, которые меньше ср. знач. модулей координат: {arrayVector2.SumLessFromNechetIndex()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Прозведение положительных четных координат: {arrayVector2.MultChet()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        try
        {
            Console.WriteLine($"Прозведение нечетных и не делящихся нацело на 3 координат: {arrayVector2.MultNechet()}");
        }
        catch (Exception error)
        {
            Console.WriteLine(error.Message);
        }
        arrayVector2.SortUp();
        arrayVector2.Log("Сортировка по возрастанию");
        arrayVector2.SortDown();
        arrayVector2.Log("Сортировка по убыванию");

        Console.WriteLine("Введите число на которое хотитет умножить оба вектора: ");
        int multNumber = int.Parse(Console.ReadLine());
        Console.WriteLine($"Первый вектор, умноженный на {multNumber}: {Vectors.MultNumber(arrayVector1, multNumber)}");
        Console.WriteLine($"Первый вектор, умноженный на {multNumber}: {Vectors.MultNumber(arrayVector2, multNumber)}");
    }
}