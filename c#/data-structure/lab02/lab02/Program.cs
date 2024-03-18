using lab02;
using System;

namespace lab02;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа #2\n 6104-020302D - Маликов Николай");

        string input;

        while (true)
        {
            Console.WriteLine("Выберете класс для работы:\n\n" +
                              "\t1. LinkedListVector\n" +
                              "\t2. ArrayVector\n");

            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    TestLinkedListVectorClass();
                    break;
                case "2":
                    TestArrayVectorClass();
                    break;
                default:
                    Console.WriteLine("Нет такого пункта в меню");
                    break;
            }
        }
    }

    public static void TestLinkedListVectorClass()
    {
        string inp;
        int length;
        do
        {
            Console.Write("Введите длину вектора: ");
            inp = Console.ReadLine();
        } while (!int.TryParse(inp, out length) || length <= 0);

        var vec = new LinkedListVector(length);
        vec.Log("Созданный вектор");

        while (true)
        {
            Console.WriteLine("Выберете действие:\n\n" +
                              "1. Добавить элемент в начало списка\n" +
                              "2. Добавить элемент в конец списка\n" +
                              "3. Добавить элемент по индексу\n" +
                              "4. Удалить первый элемент\n" +
                              "5. Удалить последний элемент\n" +
                              "6. Удалить элемент по индексу\n" +
                              "0. Выход в меню\n");

            inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                    {
                        int value;
                        do
                        {
                            Console.Write("Введите значение для добавления: ");
                            inp = Console.ReadLine();
                        } while (!int.TryParse(inp, out value));

                        vec.AddElementToStart(value);
                        vec.Log("Обновленный вектор");
                        break;
                    }
                case "2":
                    {
                        int value;
                        do
                        {
                            Console.Write("Введите значение для добавления: ");
                            inp = Console.ReadLine();
                        } while (!int.TryParse(inp, out value));

                        vec.AddElementToEnd(value);
                        vec.Log("Обновленный вектор");
                        break;
                    }
                case "3":
                    {
                        int value;
                        do
                        {
                            Console.Write("Введите позицию для добавления: ");
                            inp = Console.ReadLine();
                        } while (!int.TryParse(inp, out value));

                        int idx;
                        do
                        {
                            Console.Write("Введите значение для добавления элемента: ");
                            inp = Console.ReadLine();
                        } while (!int.TryParse(inp, out idx));

                        try
                        {
                            vec.AddElementAtPosition(idx, value);
                            vec.Log("Обновленный вектор");
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Введенный индекс выходит за рамки связного списка");
                        }
                        break;
                    }
                case "4":
                    {
                        try
                        {
                            vec.RemoveElementFromStart();
                            vec.Log("Обновленный вектор");
                        }
                        catch
                        {
                            Console.WriteLine("Пустой вектор");
                        }
                        break;
                    }
                case "5":
                    {
                        try
                        {
                            vec.RemoveElementFromEnd();
                            vec.Log("Обновленный вектор");
                        }
                        catch
                        {
                            Console.WriteLine("Пустой вектор");
                        }
                        break;
                    }
                case "6":
                    {
                        int idx;
                        do
                        {
                            Console.Write("Введите индекс элемента который хотите удалить: ");
                            inp = Console.ReadLine();
                        } while (!int.TryParse(inp, out idx));

                        try
                        {
                            vec.RemoveElementAtPosition(idx);
                            vec.Log("Обновленный вектор");
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("Введенный индекс выходит за рамки связного списка");
                        }

                        break;
                    }
                case "0":
                    {
                        return;
                    }
                default:
                    {
                        Console.WriteLine("Нет такого пункта в меню");
                        break;
                    }
            }
        }
    }

    public static void TestArrayVectorClass()
    {
        string inp;

        ArrayVector vector = ArrayVector.UserInput();
        vector.Log();

        while (true)
        {
            ArrayVector vector2;

            Console.WriteLine("Выберете действие:\n\n" +
                              "\t1. Создать новый вектор\n" +
                              "\t2. Найти модуль вектора\n" +
                              "\t3. Сумма двух векторов\n" +
                              "\t4. Скаляр двух векторов\n" +
                              "\t0. Выход");

            inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                    vector = ArrayVector.UserInput();
                    vector.Log("Новый вектор");
                    break;
                case "2":
                    Console.WriteLine($"Модуль вектора равен: {vector.GetNorm()}");
                    break;
                case "3":
                    vector2 = ArrayVector.UserInput();
                    vector.Log("Первый вектор");
                    vector2.Log("Второй вектор");
                    Vectors.Sum(vector, vector2).Log("Результат сложения двух векторов");
                    break;
                case "4":
                    vector2 = ArrayVector.UserInput();
                    vector.Log("Первый вектор");
                    vector2.Log("Второй вектор");
                    Console.WriteLine($"Результат скалярного умножения векторов: {Vectors.Scalar(vector, vector2)}");
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Нет такого пункта в меню");
                    break;
            }
        }
    }
}