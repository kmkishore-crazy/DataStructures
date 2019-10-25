using System.Collections;
using System.Collections.Generic;

namespace LinkedListDataStructure
{
    public class LinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }

        public LinkedListNode<T> Tail { get; private set; }

        #region Add

        public void AddFirst(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddFirst(newNode);
        }

        public void AddFirst(LinkedListNode<T> newNode)
        {
            if (Count == 0)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
            }

            Head = newNode;
            Count++;
        }

        public void AddLast(T value)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(value);
            AddLast(newNode);
        }

        public void AddLast(LinkedListNode<T> newNode)
        {
            if (Count == 0)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
            }

            Tail = newNode;
            Count++;
        }

        #endregion Add

        #region Remove

        public void RemoveFirst()
        {
            if (Count > 0)
            {
                Head = Head.Next;
                if (Count == 1)
                {
                    Tail = null;
                }
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Count > 0)
            {
                if (Count == 1)
                {
                    Head = Tail = null;
                }
                else
                {
                    LinkedListNode<T> current = Head;
                    while (current.Next != Tail)
                    {
                        current = current.Next;
                    }
                    current.Next = null;
                    Tail = current;
                }
                Count--;
            }
        }

        #endregion Remove

        #region ICollection Implementation

        public int Count { get; private set; } = 0;

        public bool IsReadOnly { get; } = false;

        public void Add(T item)
        {
            AddLast(item);
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    return true;
                }
                current = current.Next;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            LinkedListNode<T> current = Head;
            while(current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> current = Head;
            LinkedListNode<T> previous = null;
            while(current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            Tail = previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
                previous = current;
                current = current.Next;
            }

            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)this).GetEnumerator();
        }

        #endregion ICollection Implementation
    }
}
