using lab04;
using System;

namespace lab04;

public static class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Лабораторная работа #3\n 6104-020302D - Маликов Николай");
        TestArrayVectorsClass();
        // string input;
        //
        // while (true)
        // {
        //     Console.WriteLine("Выберете класс для работы:\n\n" +
        //                       "\t1. LinkedListVector\n" +
        //                       "\t2. ArrayVector\n" +
        //                       "\t3. LinkedListVector + ArrayVector\n" +
        //                       "\t4. Array Vectors");
        //
        //     input = Console.ReadLine();
        //
        //     switch (input)
        //     {
        //         case "1":
        //             TestLinkedListVectorClass();
        //             break;
        //         case "2":
        //             TestArrayVectorClass();
        //             break;
        //         case "3":
        //             TestInterfaceClass();
        //             break;
        //         case "4":
        //             TestArrayVectorsClass();
        //             break;
        //         default:
        //             Console.WriteLine("Нет такого пункта в меню");
        //             break;
        //     }
        // }
    }


    public static void TestArrayVectorsClass()
    {
        List<IVectorable> arr = new List<IVectorable>();
        string inp;
        LogVectors(arr);
        while (true)
        {
            Console.WriteLine("Выберете класс для работы:\n\n" +
                              "\t1. Добавить вектор\n" +
                              "\t2. Убрать вектор\n" +
                              "\t3. Вывести вектора с минимальным и максимальным количеством координат\n" +
                              "\t4. Отсортировать массив векторов по возрастанию их модулей\n" +
                              "\t5. Клонировать вектор\n" +
                              "\t6. Сложение векторов\n" +
                              "\t7. Модуль вектора\n" +
                              "\t8. Скалярное произведение вектора\n" +
                              "\t9. \n");

            inp = Console.ReadLine();

            switch (inp)
            {
                case "1":
                    arr.Add(CreateVector());
                    break;
                case "2":
                    Console.WriteLine("Укажите индекс по которому хотитете удалить вектор:");
                    int inp1 = Convert.ToInt32(Console.ReadLine());
                    arr.Remove(arr[inp1 - 1]);
                    LogVectors(arr);
                    break;
                case "3":
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
                    
                    break;
                case "4":
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
                    break;
                case "5":
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
                    break;
                case "6":
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
                    break;
                case "7":
                    IVectorable vecc = CreateVector();
                    vecc.Log();
                    double resullt = Vectors.GetNormSt(vecc);
                    Console.WriteLine($"Модуль равен: {resullt}");
                    break;
                case "8":
                    IVectorable vectorr = CreateVector();
                    vectorr.Log();
                    IVectorable vectorr1 = CreateVector();
                    vectorr1.Log();
                
                    double result = Vectors.Scalar(vectorr, vectorr1);
                    Console.WriteLine($"Скаляр равен: {result}");
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

    public static void TestInterfaceClass()
    {
        
        IVectorable vector = CreateVector();
        vector.Log();

        Console.WriteLine("Выберите операцию:\n" +
                          "\t1. Сложение\n" +
                          "\t2. Модуль\n" +
                          "\t3. Скаляр\n");
        string inp = Console.ReadLine();
        switch (inp)
        {
            case "1":
            {
                IVectorable vector1 = CreateVector();
                vector1.Log();
                try
                {
                    IVectorable result = Vectors.Sum(vector, vector1);
                    result.Log();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Вектора разного размера!");
                }
                break;
            }
            case "2":
            {
                double result = Vectors.GetNormSt(vector);
                Console.WriteLine($"Модуль равен: {result}");
                break;
            }
            case "3":
            {
                IVectorable vector1 = CreateVector();
                vector1.Log();
                
                double result = Vectors.Scalar(vector, vector1);
                Console.WriteLine($"Скаляр равен: {result}");
                break;
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
                    vec.Log("Созданный вектор");
                    return vec;
                    break;
                case "2":
                    ArrayVector vector = ArrayVector.UserInput();
                    vector.Log("Новый вектор");
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