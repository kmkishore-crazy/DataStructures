using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedListDataStructure
{
    public class DoublyLinkedList<T> : ICollection<T>
    {
        public DoublyLinkedListNode<T> Head { get; private set; }

        public DoublyLinkedListNode<T> Tail { get; private set; }

        #region Add

        public void AddFirst(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            AddFirst(newNode);
        }

        public void AddFirst(DoublyLinkedListNode<T> newNode)
        {
            if (Count == 0)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next = Head;
                Head.Previous = newNode;
            }

            Head = newNode;
            Count++;
        }

        public void AddLast(T value)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(value);
            AddLast(newNode);
        }

        public void AddLast(DoublyLinkedListNode<T> newNode)
        {
            if (Count == 0)
            {
                Head = newNode;
            }
            else
            {
                Tail.Next = newNode;
                newNode.Previous = Tail;
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
                else
                {
                    Head.Previous = null;
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
                    Tail.Previous.Next = null;
                    Tail = Tail.Previous;
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
            DoublyLinkedListNode<T> current = Head;
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
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                array[arrayIndex++] = current.Value;
                current = current.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        public bool Remove(T item)
        {
            DoublyLinkedListNode<T> current = Head;
            while (current != null)
            {
                if (current.Value.Equals(item))
                {
                    if (current.Previous != null)
                    {
                        current.Previous.Next = current.Next;
                        if (current.Next == null)
                        {
                            Tail = current.Previous;
                        }
                        else
                        {
                            current.Next.Previous = current.Previous;
                        }
                        Count--;
                    }
                    else
                    {
                        RemoveFirst();
                    }
                    return true;
                }
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
