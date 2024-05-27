﻿using lab06;
using System;
using System.Text.Json;

namespace lab06;

public static class Program
{
    public delegate void TestFunctionProgramMenu(List<IVectorable> arr);

    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа #6\n 6104-020302D - Маликов Николай\n");

        Console.WriteLine("Выберете класс для работы:\n\n" +
                          "\t1. Добавить вектор\n" +
                          "\t2. Убрать вектор\n" +
                          "\t3. Вывести вектора с минимальным и максимальным количеством координат\n" +
                          "\t4. Отсортировать массив векторов по возрастанию их модулей\n" +
                          "\t5. Клонировать вектор\n" +
                          "\t6. Сложение векторов\n" +
                          "\t7. Модуль вектора\n" +
                          "\t8. Скалярное произведение вектора\n" +
                          "\t9. Запись вектора в бинарный поток\n" +
                          "\t10. Запись вектора в текстовый файл\n" +
                          "\t11. Сериализация вектора\n");
        
        List<IVectorable> arr = new List<IVectorable>();
        TestFunctionProgramMenu menu = null;

        Console.Write("Введите порядок выполнения действий программы через пробел: ");
        string[] inp = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (string comand in inp)
        {
            switch (comand)
            {
                case "1":
                    menu += AddVector;
                    break;
                case "2":
                    menu += RemoveVector;
                    break;
                case "3":
                    menu += VectorsMinAndMaxCountCoordinates;
                    break;
                case "4":
                    menu += SortArrayVectorsForUpsModules;
                    break;
                case "5":
                    menu += CloneVector;
                    break;
                case "6":
                    menu += SummVectors;
                    break;
                case "7":
                    menu += ModuleVectors;
                    break;
                case "8":
                    menu += ScalarMultVectors;
                    break;
                case "9":
                    menu += BinaryFlow;
                    break;
                case "10":
                    menu += FileFlow;
                    break;
                case "11":
                    menu += SerializedeMethod;
                    break;
                default:
                    Console.WriteLine("Нет такого пункта в меню");
                    break;
                
            }
        }
        menu(arr);
        Console.WriteLine("Программа завершила свое выполнение!");
        Console.ReadKey();
    }

    public static void AddVector(List<IVectorable> arr)
    {
        try
        {
            arr.Add(CreateVector());
        }
        catch (Exception e)
        {
            Console.WriteLine("В данный момент это действие не возможно!");
            throw;
        }
    }

    public static void RemoveVector(List<IVectorable> arr)
    {
        try
        {
            Console.WriteLine("Укажите индекс по которому хотитете удалить вектор:");
            int inp1 = Convert.ToInt32(Console.ReadLine());
            arr.Remove(arr[inp1 - 1]);
            LogVectors(arr);
        }
        catch (Exception e)
        {
            Console.WriteLine("В данный момент это действие не возможно!");
            throw;
        }
    }

    public static void VectorsMinAndMaxCountCoordinates(List<IVectorable> arr)
    {
        try
        {
            int minLength = arr[0].Length;
            int maxLength = arr[0].Length;

            for (int i = 0; i < arr.Count; i++)
            {
                if (maxLength < arr[i].Length)
                {
                    maxLength = arr[i].Length;
                }

                if (minLength > arr[i].Length)
                {
                    minLength = arr[i].Length;
                }
            }

            Console.WriteLine("Вектора с мин. значением координат: ");
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].Length == minLength)
                {
                    Console.WriteLine($"{arr[i].ToString()}");
                }
            }

            Console.WriteLine("Вектора с макс. значением координат: ");
            for (int i = 0; i < arr.Count; i++)
            {
                if (arr[i].Length == maxLength)
                {
                    Console.WriteLine($"{arr[i].ToString()}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Вектора отсутствуют");
            throw;
        }
    }

    public static void SortArrayVectorsForUpsModules(List<IVectorable> arr)
    {
        IVectorable temp;
        Comparer comparer = new Comparer();

        for (int i = 0; i < arr.Count - 1; i++)
        {
            for (int j = i + 1; j < arr.Count; j++)
            {
                if (comparer.Compare(arr[i], arr[j]) > 0)
                {
                    temp = arr[j];
                    arr[j] = arr[i];
                    arr[i] = temp;
                }
            }
        }

        Console.WriteLine("Список векторов после сортировки по модулю: ");

        for (int i = 0; i < arr.Count; ++i)
        {
            IVectorable vec1 = arr[i];
            vec1.Log($"{i + 1} Модуль: {vec1.GetNorm()}");
        }
    }

    public static void CloneVector(List<IVectorable> arr)
    {
        LogVectors(arr);
        int idx;
        string input;

        do
        {
            Console.Write("Введите номер вектора для клонирования: ");
            input = Console.ReadLine();
        } while (!Int32.TryParse(input, out idx) || idx < 1 || idx > arr.Count);

        var vec = arr[idx - 1];
        IVectorable clone;
        if (vec is ArrayVector)
        {
            clone = (vec as ArrayVector).Clone() as IVectorable;
        }
        else
        {
            clone = (vec as LinkedListVector).Clone() as IVectorable;
        }

        arr.Add(clone);
        LogVectors(arr);
    }

    public static void SummVectors(List<IVectorable> arr)
    {
        IVectorable vect = CreateVector();
        vect.Log();
        IVectorable vect1 = CreateVector();
        vect1.Log();

        try
        {
            IVectorable resulta = Vectors.Sum(vect, vect1);
            resulta.Log();
        }
        catch (Exception e)
        {
            Console.WriteLine("Вектора разного размера!");
        }
    }
    
     public static void BinaryFlow(List<IVectorable> arr)
    {
        IVectorable vec = CreateVector();
        FileStream inpStream;
        try
        {
            inpStream = new FileStream("forVector.bin", FileMode.CreateNew);
        }
        catch
        {
            inpStream = new FileStream("forVector.bin", FileMode.Truncate, FileAccess.Write, FileShare.None);
        }

        Vectors.OutputVector(vec, inpStream);
        inpStream.Close();
        Console.WriteLine("Успешно записан!");

        FileStream outputStream = new FileStream("forVector.bin", FileMode.Open, FileAccess.Read, FileShare.None);

        Console.WriteLine("\nПрочитанный вектор: " + Vectors.InputVector(outputStream).ToString());

        outputStream.Close();
    }

    public static void FileFlow(List<IVectorable> arr)
    {
        IVectorable vec = CreateVector();

        FileStream inpStream;
        
        try
        {
            inpStream = new FileStream("forVector.txt", FileMode.CreateNew, FileAccess.Write, FileShare.None);
        }
        catch
        {
            inpStream = new FileStream("forVector.txt", FileMode.Truncate, FileAccess.Write, FileShare.None);
        }

        StreamWriter print = new StreamWriter(inpStream);

        Vectors.WriteVector(vec, print);
        Console.WriteLine("Успешно записан в .txt!");
        inpStream.Close();

        FileStream outputStream = new FileStream("forVector.txt", FileMode.Open, FileAccess.Read, FileShare.None);
        StreamReader reader = new StreamReader(outputStream);

        try
        {
            Console.WriteLine("Прочитанный вектор:" + Vectors.ReadVector(reader));
        }
        catch (System.FormatException e)
        {
            Console.WriteLine(e.Message);
        }

        outputStream.Close();
    }
    
    public static void SerializedeMethod(List<IVectorable> arr)
    {
        ArrayVector vec = ArrayVector.UserInput();
        string serializedVector = JsonSerializer.Serialize(vec);
        FileStream inpStream;
        try
        {
            inpStream = new FileStream("forVector.json", FileMode.CreateNew, FileAccess.Write, FileShare.None);
        }
        catch
        {
            inpStream = new FileStream("forVector.json", FileMode.Truncate, FileAccess.Write, FileShare.None);
        }

        StreamWriter print = new StreamWriter(inpStream);
        print.Write(serializedVector);
        print.Close();
        inpStream.Close();

        Console.WriteLine("Успешно записан!");

        FileStream outputStream = new FileStream("forVector.json", FileMode.Open, FileAccess.Read, FileShare.None);

        Console.WriteLine("Прочитанный вектор: " + JsonSerializer.Deserialize<ArrayVector>(outputStream));
        outputStream.Close();
    }

    public static void ModuleVectors(List<IVectorable> arr)
    {
        IVectorable vecc = CreateVector();
        vecc.Log();
        double resullt = Vectors.GetNormSt(vecc);
        Console.WriteLine($"Модуль равен: {resullt}");
    }

    public static void ScalarMultVectors(List<IVectorable> arr)
    {
        IVectorable vectorr = CreateVector();
        vectorr.Log();
        IVectorable vectorr1 = CreateVector();
        vectorr1.Log();
        double result = Vectors.Scalar(vectorr, vectorr1);
        Console.WriteLine($"Скаляр равен: {result}");
    }

    public static void TestLinkedListVectorClass(LinkedListVector vec)
    {
        string inp;

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
                              "0. Продолжить\n");

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
    
    public static IVectorable CreateVector()
    {
        while (true)
        {
            Console.WriteLine("Вектор какого типа вы хотите создать?\n" +
                              "\t1. LinkedListVector\n" +
                              "\t2. ArrayVector\n");
            string Input = Console.ReadLine();
            
            switch (Input)
            {
                case "1":
                    string inp;
                    int length;
                    LinkedListVector vec = LinkedListVector.UserInput();
                    TestLinkedListVectorClass(vec);
                    return vec;
                    break;
                case "2":
                    ArrayVector vector = ArrayVector.UserInput();
                    return vector;
                    break;
                default:
                    Console.WriteLine("Такого пункта нет в меню");
                    break;
            }
        }
    }
    
    public static void LogVectors(List<IVectorable> vectors)
    {
        for (int i = 0; i < vectors.Count; ++i)
        {
            IVectorable vec = vectors[i];

            string typeView = vec is ArrayVector ? "ArrayVector" : "LinkedListVector";
            
            vec.Log($"{i + 1}: {typeView}");
        }
    }
}