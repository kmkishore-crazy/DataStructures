using LinkedListDataStructure;
using System;

namespace DataStructures
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList<int> list = new DoublyLinkedList<int>();
            list.Add(5);
            list.Add(7);
            list.RemoveFirst();
            list.AddFirst(5);
            list.RemoveLast();
            list.AddLast(8);

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
