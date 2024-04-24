using System.Xml.Linq;

namespace lab04;

public class LinkedListVector : IVectorable
{
    private class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }

        public Node()
        {
            Data = 0;
            Next = null;
        }

        public Node(int data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private int length;

    public LinkedListVector(int length)
    {
        this.length = length;
        head = new Node();
        Node current = head;
        for (int i = 1; i < length; i++)
        {
            current.Next = new Node();
            current = current.Next;
        }
    }

    public LinkedListVector() : this(5) { }

    public int this[int index]
    {
        get
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Data;
        }
        set
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Invalid index");
            }
            Node current = head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }

            current.Data = value;
        }
    }

    public double GetNorm()
    {
        double norm = 0;
        Node current = head;
        while (current != null)
        {
            norm += Math.Pow(current.Data, 2);
            current = current.Next;
        }
        return Math.Sqrt(norm);
    }

    public int Length
    {
        get { return length; }
    }

    public void AddElementToEnd(int element)
    {
        Node current = head;
        while (current.Next != null)
        {
            current = current.Next;
        }
        current.Next = new Node(element);
        length++;
    }

    public void AddElementToStart(int element)
    {
        Node newHead = new Node(element);
        newHead.Next = head;
        head = newHead;
        length++;
    }

    public void AddElementAtPosition(int element, int position)
    {
        if (position < 0 || position > length)
        {
            throw new IndexOutOfRangeException("Invalid position");
        }

        if (position == 0)
        {
            AddElementToStart(element);
            return;
        }

        Node current = head;
        for (int i = 1; i < position; i++)
        {
            current = current.Next;
        }

        Node newNode = new Node(element);
        newNode.Next = current.Next;
        current.Next = newNode;

        length++;
    }

    public void RemoveElementFromEnd()
    {
        if (head == null || head.Next == null)
        {
            throw new InvalidOperationException("Cannot remove from an empty list");
        }

        Node current = head;
        while (current.Next.Next != null)
        {
            current = current.Next;
        }

        current.Next = null;
        length--;
    }

    public void RemoveElementFromStart()
    {
        if (head == null)
        {
            throw new InvalidOperationException("Cannot remove from an empty list");
        }

        head = head.Next;
        length--;
    }

    public void RemoveElementAtPosition(int position)
    {
        if (position < 0 || position >= length)
        {
            throw new IndexOutOfRangeException("Invalid position");
        }

        if (position == 0)
        {
            RemoveElementFromStart();
            return;
        }

        Node current = head;
        for (int i = 1; i < position; i++)
        {
            current = current.Next;
        }

        current.Next = current.Next.Next;

        length--;
    }
    
    public static LinkedListVector UserInput()
    {
        string inp;
        int length;

        do
        {
            Console.Write("Введите длину вектора: ");
        } while (!int.TryParse(Console.ReadLine(), out length) || length <= 0);

        LinkedListVector vec = new LinkedListVector(length);

        for (int i = 0; i < length; i++)
        {
            int value;
            do
            {
                Console.Write($"Введите значение координаты {{{i + 1}}}: ");
                inp = Console.ReadLine();
            } while (!int.TryParse(inp, out value));

            vec[i] = value;
        }
        return vec;
    }
    
    public void Log(string message = "")
    {
        if (message != "") Console.Write($"{message}: ");

        var current = head;
        Console.Write("{");
        while (current != null)
        {
            if (current.Next == null)
            {
                Console.Write(current.Data);
            }
            else
            {
                Console.Write(current.Data + ", ");
            }
            current = current.Next;
        }
        Console.WriteLine("}");
    }

    public override string ToString()
    {
        string result = length.ToString() + ' ';
        for (int i = 0; i < length; i++)
        {
           result = result + this[i].ToString() + ' ';
        }
        return result;
    }
}