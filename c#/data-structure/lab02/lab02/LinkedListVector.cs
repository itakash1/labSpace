using System.Xml.Linq;

namespace lab02;

public class LinkedListVector
{
    private Node head;

    private class Node
    {
        public int value = 0;
        public Node next = null;

        public Node(int value)
        {
            this.value = value;
            next = null;
        }
    }

    public LinkedListVector()
    {
        var r = new Random();
        
        head = new Node(r.Next(100));
        Node cur = head;
        
        for (int i = 0; i < 5; i++)
        {
            cur.next = new Node(r.Next(100));
            cur = cur.next;
        }
    }
    
    public LinkedListVector(int length)
    {
        var r = new Random();
        
        head = new Node(r.Next(100));
        Node cur = head;
        
        for (int i = 0; i < length; i++)
        {
            cur.next = new Node(r.Next(100));
            cur = cur.next;
        }
    }

    public int this[int idx]
    {
        get
        {
            if (0 <= idx && idx <= Length)
            {
                Node cur = head;
                for (int i = 0; i < idx; i++)
                {
                    cur = cur.next;
                }

                return cur.value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс за границами связного списка");
            }
        }
        
        set
        {
            if (0 <= idx && idx <= Length)
            {
                Node cur = head;
                for (int i = 0; i < idx; i++)
                {
                    cur = cur.next;
                }

                cur.value = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Индекс за границами связного списка");
            }
        }
    }

    public int Length // свойство - return кол-во узлов в списке
    {
        get
        {
            if (head == null)
            {
                return -1;
            }

            int length = 0;
            Node cur = head;
            while (cur.next != null)
            {
                cur = cur.next;
                length++;
            }

            return length;
        }
    }

    public double GetNorm()
    {
        double acc = 0;
        Node cur = head;
        for (int i = 0; i < Length; i++)
        {
            acc += Math.Pow(cur.value, 2);
            cur = cur.next;
        }

        return Math.Sqrt(acc);
    }
    
    public void InsertByIndex(int idx, int value)
    {
        if (idx < 0 || idx > Length) throw new IndexOutOfRangeException("Индекс за границами связного списка");

        Node node = new Node(value); // создаем новый узел со значением с которым будем работать т.е вставлять в список

        if (idx == 0) {
            node.next = head;
            head = node;
            return;
        }

        Node cur = head;
        int curIndex = 0;
        while (cur != null && curIndex < idx - 1) {
            cur = cur.next;
            curIndex++;
        }

        if (cur == null) throw new IndexOutOfRangeException("Индекс за границами связного списка");

        node.next = cur.next;   //для следующего уже созданного узла (node) ставится следующий узел текущего (cur) => все двигается *** 
        cur.next = node;        // Если индекс равен нулю, то новый узел становится
                                // головой списка, иначе он добавляется после существующего узла с индексом, предшествующим указанному.
    }

    public void InsertToStart(int value)
    {
        InsertByIndex(0, value);
    }
    
    public void InsertToEnd(int value)
    {
        InsertByIndex(Length, value);
    }
    
    public void DeleteByIndex(int idx)
    {
        if (head == null) throw new Exception("Связный список пуст");
        if (idx < 0 || idx >= Length) throw new IndexOutOfRangeException("Индекс за границами связного списка");

        Node cur = head;

        if (idx == 0) 
        {
            head = cur.next;
            return;
        }

        for (int i = 0; cur != null && i < idx - 1; i++)
        {
            cur = cur.next;
        }

        if (cur == null || cur.next == null) return;

        cur.next = cur.next.next;
    }

    public void DeleteFromStart()
    {
        DeleteByIndex(0);
    }

    public void DeleteFromEnd()
    {
        DeleteByIndex(Length - 1);
    }

    public void Log(string message = "")
    {
        if (message != "") Console.Write($"{message}: ");
        
        var cur = head;
        Console.Write("{");
        while (cur.next != null)
        {
            if (cur.next.next == null)
            {
                Console.Write(cur.value);
            }
            else
            {
                Console.Write(cur.value + ", ");
            }
            cur = cur.next;
        }
        Console.WriteLine("}");
    }
}