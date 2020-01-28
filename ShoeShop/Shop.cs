using System;
using System.Collections.Generic;
using System.Linq;


namespace ShoeShop
{
    class Shop
    {
        private readonly List<Shoe> shelf;
        SortAscendingShoesNumbers byNumber = new SortAscendingShoesNumbers();

		public Shop(List<Shoe> _shelf)
		{
			shelf = _shelf;
		}


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
		/// Add a new pair of shoes in the shop and sort the the shoes after their number.
		/// </summary>
		/// <param name="shoe"></param>
		public void Add(Shoe shoe)
		{
			shelf.Add(shoe);
			shelf.Sort(byNumber);
		}

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
		/// Verify is the offer of shoes in balanced or not.
		/// </summary>
		/// <returns></returns>
		public Boolean isBalancedTheOffer()
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
		/// Print the total price that the client will pay for the selected shoes and the list of shoes left on the shelf.
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

			uint totalPrice = 0;
			var copy = new List<Shoe>();
			foreach (var shoe in shoesTakenFromTheShelf)
			{
				copy.Add(shoe);
			}

			int clientNumber = 36;
			Console.WriteLine("==================================");
			Console.WriteLine("List of shoes bought by the client");
			for (int i = 0; i < shoesTakenFromTheShelf.Count; i+=2)
			{
				if (copy.ElementAt(i).Number == clientNumber)
				{
					if (i % 2 == 0)
					{
						Shoe shoe = copy.ElementAt(i);
						totalPrice += shoe.Price;
						shoesTakenFromTheShelf.Remove(shoe);	
						Console.WriteLine(shoe);
					}
				}
			}
			if (totalPrice == 0)
			{
				Console.WriteLine("There is no pair of shoes in the even selected range that has the same number as the client.");
			}
			else
			{
				Console.WriteLine($"Total price = {totalPrice}");
			}

			totalPrice = 0;
			Console.WriteLine("==================================");
			Console.WriteLine("List of shoes bought by the client");
			for (int i = 0; i < shoesTakenFromTheShelf.Count; i+=2)
			{
				if (copy.ElementAt(i).Number == clientNumber)
				{
					if (i % 2 != 0)
					{
						Shoe shoe = copy.ElementAt(i);
						totalPrice += shoe.Price;
						shoesTakenFromTheShelf.Remove(shoe);
						Console.WriteLine(shoe);
					}
				}
			}
			if (totalPrice == 0)
			{
				Console.WriteLine("There is no pair of shoes in the odd selected range that has the same number as the client.");
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
