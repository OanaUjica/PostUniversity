using System;

namespace GenericCollectionsImplementedWithDynamicArray
{
    class Run
    {
        static void Main(string[] args)
        {
            // Instantiate the Bag collection.
            Bag<int> collection = new Bag<int>();

            // Add elements in the Bag.
            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }

            // Print the elements in the Bag.
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            // Remove an element and print the elements of the Bag after removal.
            collection.Remove(7);
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();

            // Print the numar of elements in the Bag.
            uint length = collection.Length();
            Console.WriteLine($"Length: {length}");
        }
    }
}
