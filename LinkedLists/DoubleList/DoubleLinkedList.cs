using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleList;
public class DoublyLinkedList<T>
{
    private DoubleNode<T>? _head;
    private DoubleNode<T>? _tail;

    public DoublyLinkedList()
    {
        _tail = null;
        _head = null;
    }

    
    private void InsertAtEnd(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
    }

    public void InsertSorted(T data)
    {
        var newNode = new DoubleNode<T>(data);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
            return;
        }

        var current = _head;
        while (current != null && string.Compare(data!.ToString(), current.Data!.ToString(), StringComparison.CurrentCultureIgnoreCase) > 0)

        {
            current = current.Next;
        }

        if (current == _head)
        {
            newNode.Next = _head;
            _head.Prev = newNode;
            _head = newNode;
        }
        else if (current == null)
        {
            _tail!.Next = newNode;
            newNode.Prev = _tail;
            _tail = newNode;
        }
        else
        {
            newNode.Prev = current.Prev;
            newNode.Next = current;
            current.Prev!.Next = newNode;
            current.Prev = newNode;
        }
    }

    public void SortDescending()
    {
        var values = new List<T>();
        var current = _head;

        while (current != null)
        {
            values.Add(current.Data!);
            current = current.Next;
        }

        values.Sort((a, b) => string.Compare(b!.ToString(), a!.ToString(), StringComparison.CurrentCultureIgnoreCase));


        _head = null;
        _tail = null;
        foreach (var val in values)
        {
            InsertAtEnd(val);
        }
    }

    public bool Exists(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(value))
                return true;
            current = current.Next;
        }
        return false;
    }
    public void RemoveFirstOccurrence(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(value))
            {
                if (current.Prev != null)
                    current.Prev.Next = current.Next;
                else
                    _head = current.Next;

                if (current.Next != null)
                    current.Next.Prev = current.Prev;
                else
                    _tail = current.Prev;

                return; 
            }
            current = current.Next;
        }
    }



    public void RemoveAllOccurrences(T value)
    {
        var current = _head;
        while (current != null)
        {
            if (current.Data!.Equals(value))
            {
                var toRemove = current;
                current = current.Next;
               
                if (toRemove.Prev != null)
                    toRemove.Prev.Next = toRemove.Next;
                else
                    _head = toRemove.Next;

                if (toRemove.Next != null)
                    toRemove.Next.Prev = toRemove.Prev;
                else
                    _tail = toRemove.Prev;
            }
            else
            {
                current = current.Next;
            }
        }
    }

    public List<T> GetModes()
    {
        var frequency = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (frequency.ContainsKey(current.Data!))
                frequency[current.Data!] += 1;
            else
                frequency[current.Data!] = 1;
            current = current.Next;
        }

        int max = frequency.Values.Max();
        return frequency.Where(pair => pair.Value == max).Select(pair => pair.Key).ToList();
    }

    public void DisplayFrequencyGraph()
    {
        var frequency = new Dictionary<T, int>();
        var current = _head;

        while (current != null)
        {
            if (frequency.ContainsKey(current.Data!))
                frequency[current.Data!] += 1;
            else
                frequency[current.Data!] = 1;
            current = current.Next;
        }

        foreach (var pair in frequency)
        {
            Console.WriteLine($"{pair.Key}: {new string('*', pair.Value)}");
        }
    }

    public string GetForward()
    {
        var result = new List<string>();
        var current = _head;

        while (current != null)
        {
            result.Add(current.Data?.ToString() ?? "null");
            current = current.Next;
        }

        return string.Join(" -> ", result) + " -> null";
    }

    public string GetBackward()
    {
        var result = new List<string>();
        var current = _tail;

        while (current != null)
        {
            result.Add(current.Data?.ToString() ?? "null");
            current = current.Prev;
        }

        return string.Join(" <- ", result) + " <- null";
    }
}

