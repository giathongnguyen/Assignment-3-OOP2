using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Assignment3.ProblemDomain;

namespace Assignment3.Utility
{
    [Serializable]
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Counter { get; set; }

        public SLL()
        {
            Head = null;
            Tail = null;
            Counter = 0;
        }

        public bool IsEmpty() 
        {
            return Counter == 0;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Counter = 0;
        }

        public void AddLast(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                Head = Tail = newNode;
            }
            else
            {
                Tail.Next = newNode;
                Tail = newNode;
            }
            Counter++;
        }

        public void AddFirst(User value)
        {
            Node newNode = new Node(value);
            if (IsEmpty())
            {
                Head = Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head = newNode;
            }
            Counter++;
        }

        public void Add(User value, int index)
        {
            if (index < 0 || index > Counter)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == Counter)
            {
                AddLast(value);
            }
            else
            {
                Node newNode = new Node(value);
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                newNode.Next = current.Next;
                current.Next = newNode;
                Counter++;
            }
        }

        public void Replace(User value, int index)
        {
            if (index < 0 || index >= Counter)
                throw new IndexOutOfRangeException();

            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            current.Value = value;
        }

        public int Count() 
        {
            return Counter;
        }

        public User GetValue(int index)
        {
            if (index < 0 || index >= Counter)
                throw new IndexOutOfRangeException();
            Node current = Head;
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current.Value;
        }

        public void RemoveFirst()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from an empty list.");

            Head = Head.Next;
            if (Head == null)
            {
                Tail = null;
            }
            Counter--;
        }

        public void RemoveLast()
        {
            if (IsEmpty())
                throw new InvalidOperationException("Cannot remove from an empty list.");

            if (Head == Tail)
            {
                Head = Tail = null;
            }
            else
            {
                Node current = Head;
                while (current.Next != Tail)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            Counter--;
        }

        public void Remove(int index)
        {
            if (index < 0 || index >= Counter)
                throw new IndexOutOfRangeException();

            if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == Counter - 1)
            {
                RemoveLast();
            }
            else
            {
                Node current = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                Counter--;
            }
        }



        public int IndexOf(User value)
        {
            Node current = Head;
            for (int i = 0; i < Counter; i++)
            {
                if (current.Value.Equals(value))
                {
                    return i;
                }
                current = current.Next;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }

        public void Reverse()
        {
            if (IsEmpty() || Head.Next == null)
                return;

            Node prev = null;
            Node current = Head;
            Tail = Head;
            while (current != null)
            {
                Node nextNode = current.Next;
                current.Next = prev;
                prev = current;
                current = nextNode;
            }
            Head = prev;
        }


    }
}

