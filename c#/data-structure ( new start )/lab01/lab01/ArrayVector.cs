namespace lab01;

public class ArrayVector
{
    private int[] vector;

    public ArrayVector(int length)
    {
        vector = new int[length];
    }

    public ArrayVector()
    {
        vector = new int[5];
    }

    public int Length => vector.Length;

    public int this[int idx]
    {
        get
        {
            if (idx < 0 || idx >= Length)
            {
                throw new IndexOutOfRangeException("Vector index out of range");
            }
            return vector[idx];
        }
        set
        {
            if (idx < 0 || idx >= Length)
            {
                throw new IndexOutOfRangeException("Vector index out of range");
            }
            vector[idx] = value;
        }
    }

    public double GetNorm()
    {
        double result = 0;
        for (int i = 0; i < vector.Length; i++)
        {
            result += Math.Pow(vector[i], 2);
        }
        return Math.Sqrt(result);
    }

    public int SumPositivesFromChetIndex()
    {
        int result = 0;
        for (int i = 1; i < vector.Length; i += 2)
        {
            if (vector[i] > 0)
            {
                result += vector[i];
            }
        }
        return result;
    }

    public int SumLessFromNechetIndex()
    {
        int abs = 0;
        for (int i = 0; i < vector.Length; i++)
        {
            abs += Math.Abs(vector[i]);
        }
        int result = 0;
        for (int i = 0; i < vector.Length; i += 2)
        {
            if (vector[i] < abs)
            {
                result += vector[i];
            }
        }
        return result;
    }

    public int MultChet()
    {
        int result = 1;
        for (int i = 1; i < vector.Length; i += 2)
        {
            if (vector[i] % 2 == 0 && vector[i] > 0 )
            {
                if (result == 0) result = 1;
                result *= vector[i];
            }
        }
        return result;
    }

    public int MultNechet()
    {
        int result = 1;
        for (int i = 0; i < vector.Length; i += 2)
        {
            if (vector[i] % 3 != 0 && vector[i] % 2 != 0)
            {
                if (result == 0) result = 1;
                result *= vector[i];
            }
        }
        return result;
    }
    
    public void SortUp()
    {
        int n = vector.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (vector[j] > vector[j + 1])
                {
                    (vector[j], vector[j + 1]) = (vector[j + 1], vector[j]);
                }
            }
        }
    }

    public void SortDown()
    {
        int n = vector.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (vector[j] < vector[j + 1])
                {
                    (vector[j], vector[j + 1]) = (vector[j + 1], vector[j]);
                }
            }
        }
    }
    
    public static ArrayVector GetFromUserInput()
    {
        string input;
        do
        {
            Console.WriteLine("Выберете как хотите заполнить вектор:\n" +
                              "1 - Случайно\n" +
                              "2 - Ручной ввод");
            input = Console.ReadLine();
        } while (input != "1" && input != "2");

        int length;
        do
        {
            Console.Write("Введите длину вектора: ");
        } while (!int.TryParse(Console.ReadLine(), out length) || length <= 0);

        ArrayVector vec = new ArrayVector(length);

        if (input == "1")
        {
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                vec[i] = random.Next(100);
            }
            return vec;
        }
        else
        {
            for (int i = 0; i < length; i++)
            {
                int value;
                do
                {
                    Console.Write($"Введите значение координаты {{{i+1}}}: ");
                    input = Console.ReadLine();
                } while (!int.TryParse(input, out value));
                vec[i] = value;
            }
            return vec;
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
                Console.Write(vector[i]);
            }
            else
            {
                Console.Write(vector[i] + ", ");
            }
        }
        Console.WriteLine("}");
    }
}