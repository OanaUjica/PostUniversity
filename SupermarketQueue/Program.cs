using System;
using System.Collections.Generic;
using System.Linq;

namespace SupermarketQueue
{
    class Program
    {
        //There is a queue for the self-checkout tills at the supermarket.Your task is write a function to calculate the total time required for all the customers to check out!

        //input
        //customers: an array of positive integers representing the queue.Each integer represents a customer, and its value is the amount of time they require to check out.
        //n: a positive integer, the number of checkout tills.
        //output
        //The function should return an integer, the total time required.

        static void Main(string[] args)
        {

            Console.WriteLine("Tills number = ");
            int tillsNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Number of customers = ");
            int numberOfCustomers = int.Parse(Console.ReadLine());

            Console.WriteLine("Time for every customer = ");
            int[] times = new int[numberOfCustomers];
            for (int i = 0; i < numberOfCustomers; i++)
            {
                times[i] = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Total time at queue = {QueueTimeDictionary(times,tillsNumber)}");
        }


        // version using IndexOf method of Array
        public static long QueueTime(int[] customers, int n)
        {
            int[] till = new int[n];
            for (int i = 0; i < customers.Length; i++)
            {
                till[Array.IndexOf(till, till.Min())] += customers[i];
            }
            return till.Max();
        }

        // version using Sort method for Array
        public static int QueueTimeWithoutLinq(int[] customers, int n)
        {
            int[] result = new int[n];
            for (int i = 0; i < customers.Length; i++)
            {
                result[0] += customers[i];
                Array.Sort(result);
            }
            return result[n - 1];
        }

        // version using IndexOf method for List
        public static long QueueTimeRegister(int[] customers, int n)
        {
            var registers = new List<int>(Enumerable.Repeat(0, n));

            foreach (int cust in customers)
            {
                registers[registers.IndexOf(registers.Min())] += cust;
            }
            return registers.Max();
        }


        // version with Dictionary
        public static long QueueTimeDictionary(int[] customers, int n)
        {
            Dictionary<int, int> queues = new Dictionary<int, int>();

            for (int i = 1; i <= n; i++)
            {
                queues.Add(i, 0);
            }

            foreach (int customer in customers)
            {
                queues = queues.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                var lowest = queues.First();
                queues[lowest.Key] = lowest.Value + customer;
            }

            queues = queues.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            return queues.Last().Value;
        }
    }
}
