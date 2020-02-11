using System;

namespace GenericCollectionsImplementedWithDynamicArray
{
    class Run
    {
        static void Main(string[] args)
        {

            Bag<int> collection = new Bag<int>();

            for (int i = 0; i < 10; i++)
            {
                collection.Add(i);
            }

            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
