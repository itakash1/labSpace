using System.Collections;

namespace lab04;

public class Comparer
{
    public int Compare(object? obj1, object? obj2)
    {
        IVectorable vec1 = (IVectorable)obj1;
        IVectorable vec2 = (IVectorable)obj2;
        
        if (vec2.GetNorm() == vec1.GetNorm())
        {
            return 0;
        }
        else if (vec1.GetNorm() < vec2.GetNorm())
        {
            return -1;
        }
        else
        {
            return 1;
        }
    }
}