using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoeShop.Model
{
    class Shop
    {
        private readonly List<Shoe> shelf;
        SortAscendingByNumber byNumber = new SortAscendingByNumber();

		public Shop(List<Shoe> _shelf)
		{
			shelf = _shelf;
		}

		/// <summary>
		/// Print to console the initial list of shoes that are on the shelf.
		/// </summary>
		public void PrintDatabase()
		{
			shelf.Sort(byNumber);
			Console.WriteLine("==========================");
			Console.WriteLine("Initial shoes on the shelf");
			foreach (var shoe in shelf)
			{
				Console.WriteLine(shoe);
			}
			Console.WriteLine("==========================");
		}

		/// <summary>
		/// Add a new pair of shoes on the shelf and sort the shoes after their number.
		/// </summary>
		/// <param name="shoe"></param>
		public void Add(Shoe shoe)
		{
			shelf.Add(shoe);
			shelf.Sort(byNumber);
		}

		/// <summary>
		/// Print to console the list of shoes that are on the shelf after the addition of a new pair of shoes.
		/// </summary>
		public void PrintShelfUpdatedWithNewShoe()
		{
			Console.WriteLine("====================================");
			Console.WriteLine("Updated shelf with new pair of shoes");
			foreach (var shoe in shelf)
			{
				Console.WriteLine(shoe);
			}
			Console.WriteLine("====================================");
		}

		/// <summary>
		/// Verify if the offer of shoes is balanced or not.
		/// </summary>
		/// <returns> True or false. </returns>
		public Boolean IsBalancedTheOffer()
		{
			var minNumber = int.MaxValue;
			var maxNumber = int.MinValue;
			foreach (var shoe in shelf)
			{
				if (shoe.Number < minNumber)
				{
					minNumber = shoe.Number;
				}
				if (shoe.Number > maxNumber) 
				{ 
					maxNumber = shoe.Number; 
				}
			}

			var minStock = int.MaxValue;
			var maxStock = int.MinValue;
			var count = 0;
			for (int i = minNumber; i <= maxNumber; i++)
			{
				foreach (var shoe in shelf)
				{
					if (shoe.Number == i) count++;
				}

				if (count < minStock)
				{
					minStock = count;
				}

				if (count > maxStock)
				{
					maxStock = count;
				}
				count = 0;
			}

			Console.WriteLine("==============");
			Console.WriteLine($"Min = {minStock}");
			Console.WriteLine($"Max = {maxStock}");

			if (maxStock - minStock <= 3)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// Print the total price that a client will pay for the selected shoes and the list of shoes left on the shelf.
		/// </summary>
		public void Client()
		{
			int indexShoe1 = RandomIndex1();
			int indexShoe2 = RandomIndex2(indexShoe1);

			var shoesTakenFromTheShelf = new List<Shoe>();
			for (int i = indexShoe1; i <= indexShoe2; i++)
			{
				Shoe randomShoe = shelf.ElementAt(indexShoe1);
				shoesTakenFromTheShelf.Add(randomShoe);
				shelf.RemoveAt(indexShoe1);
			}
			
			var copy = new List<Shoe>();
			foreach (var shoe in shoesTakenFromTheShelf)
			{
				copy.Add(shoe);
			}

			Console.Write("Please enter the shoe number of the customer: ");
			int customerNumber = int.Parse(Console.ReadLine());

			Console.WriteLine("==================================");
			Console.WriteLine("List of shoes bought by the customer");
			uint totalPrice = 0;
			Shoe shoeChosenByTheCustomer = null;
			for (int i = 0; i < shoesTakenFromTheShelf.Count; i+=2)
			{
				if (copy.ElementAt(i).Number == customerNumber)
				{					
					if (i % 2 == 0)
					{
						shoeChosenByTheCustomer = copy.ElementAt(i);
						totalPrice += shoeChosenByTheCustomer.Price;
						shoesTakenFromTheShelf.Remove(shoeChosenByTheCustomer);	
						Console.WriteLine(shoeChosenByTheCustomer);
					}
				}
			}
			if (totalPrice == 0)
			{
				Console.WriteLine("There is no pair of shoes in the even selected range that has the same number as the customer.");
			}
			else
			{
				Console.WriteLine($"Total price = {totalPrice}");
			}

			totalPrice = 0;
			Console.WriteLine("==================================");
			Console.WriteLine("List of shoes bought by the customer");
			for (int i = 0; i < shoesTakenFromTheShelf.Count; i+=2)
			{
				if (copy.ElementAt(i).Number == customerNumber)
				{
					if (i % 2 != 0)
					{
						shoeChosenByTheCustomer = copy.ElementAt(i);
						totalPrice += shoeChosenByTheCustomer.Price;
						shoesTakenFromTheShelf.Remove(shoeChosenByTheCustomer);
						Console.WriteLine(shoeChosenByTheCustomer);
					}
				}
			}
			if (totalPrice == 0)
			{
				Console.WriteLine("There is no pair of shoes in the odd selected range that has the same number as the customer.");
			}
			else
			{
				Console.WriteLine($"Total price = {totalPrice}");
			}
			Console.WriteLine("==================================");


			foreach (var shoe in shoesTakenFromTheShelf)
			{
				shelf.Add(shoe);
			}
			shelf.Sort(byNumber);

			Console.WriteLine("==============================");
			Console.WriteLine("Shelf with the remaining shoes");
			foreach (var shoe in shelf)
			{
				Console.WriteLine(shoe);
			}
			Console.WriteLine("==============================");
		}

		private int RandomIndex1()
		{
			Random randomIndex1 = new Random();
			var indexShoe1 = randomIndex1.Next(0, shelf.Count-1);
			return indexShoe1;
		}

		private int RandomIndex2(int indexShoe1)
		{
			Random randomIndex2 = new Random();
			var indexShoe2 = randomIndex2.Next(indexShoe1+1, shelf.Count);
			return indexShoe2;
		}
	}
}
