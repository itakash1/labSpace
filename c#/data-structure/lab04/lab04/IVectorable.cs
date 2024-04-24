namespace lab04;

public interface IVectorable
{
    int Length
    {
        get;
    }
    
    int this[int index]
    {
        get;
        set;
    }

    double GetNorm();
    void Log(string message = "");
}