using Collections_NK.MyLinkedLists.DoubleLinked;
using Collections_NK.MyLinkedLists.SingleLinked;

namespace Collections_NK;
internal class Program
{
    static void Main()
    {
        DoubleLinkedList<int> list = new DoubleLinkedList<int>();
        DoubleLinkedList<int> list2 = new DoubleLinkedList<int>();

        DoubleLinkedNode<int> node1 = new DoubleLinkedNode<int>(1);
        DoubleLinkedNode<int> node2 = new DoubleLinkedNode<int>(2);


        list.AddFirst(node1);
        list.AddFirst(node2);

        list2.AddFirst(node1);
        list2.AddFirst(node2);
        list.AddFirst(node1);


        Console.WriteLine("Elements in the list:");

        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine();
    }
}