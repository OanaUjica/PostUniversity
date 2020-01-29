using System;


namespace ShoeShop.View
{
    class Menu
    {
		public static int ReadInteger(string prompter)
		{
			try
			{
				Console.WriteLine(prompter);
				int option = int.Parse(Console.ReadLine());
				return option;
			}
			catch (Exception)
			{
				Console.WriteLine("Wrong input! Please try again.");
				return ReadInteger(prompter);
			}
		}

        public static int Options()
        {
			Console.WriteLine();
			Console.WriteLine("1. Initialize and print the database.");
			Console.WriteLine("2. Add a new pair of shoes.");
			Console.WriteLine("3. Verify if the offer of shoes is balanced.");
			Console.WriteLine("4. Print the list of shoes of a client, the price paid and the list of shoes remaind on the shelf.");
			Console.WriteLine("0. Program terminated.");

			int option = ReadInteger("Please enter an option:");
			return option;
        }
    }
}
