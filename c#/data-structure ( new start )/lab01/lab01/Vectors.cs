namespace lab01;

public class Vectors
{
    public static ArrayVector Sum(ArrayVector first, ArrayVector second)
    {
        if (first.Length != second.Length)
        {
            throw new Exception("Вектора не совпадают по длине");
        }

        ArrayVector vec = new ArrayVector(first.Length);
        for (int i = 0; i < vec.Length; i++)
        {
            vec[i] = first[i] + second[i];
        }

        return vec;
    }

    public static double ScalarMultiply(ArrayVector first, ArrayVector second)
    {
        if (first.Length != second.Length)
        {
            throw new Exception("Вектора не совпадают по длине");
        }

        int result = 0;
        for (int i = 0; i < first.Length; i++)
        {
            result += first[i] * second[i];
        }

        return result;
    }

    public static ArrayVector MultiplyByNumber(ArrayVector vector, int number)
    {
        for (int i = 0; i < vector.Length; i++)
        {
            vector[i] *= number;
        }

        return vector;
    }

    public static double GetNormSt(ArrayVector vector)
    {
        return vector.GetNorm();
    }
}