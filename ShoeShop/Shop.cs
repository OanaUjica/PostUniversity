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

		/// <summary>
		/// Add a new pair of shoes in the shop and sort the the shoes after their number.
		/// </summary>
		/// <param name="shoe"></param>
		public void Add(Shoe shoe)
		{
			shelf.Add(shoe);
			shelf.Sort(byNumber);
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
			Random randomIndex1 = new Random();
			var indexShoe1 = randomIndex1.Next(0, shelf.Count);
			Random randomIndex2 = new Random();
			var indexShoe2 = randomIndex2.Next(0, shelf.Count);

			var shoesTakenFromTheShelf = new List<Shoe>();
			if (indexShoe1 < indexShoe2)
			{
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
				Console.WriteLine("==============");
				for (int i = 0; i < shoesTakenFromTheShelf.Count; i++)
				{					
					if (copy.ElementAt(i).Number == clientNumber)
					{						
						if (i % 2 == 0)
						{
							Shoe shoe = copy.ElementAt(i);
							totalPrice += shoe.Price;
							shoesTakenFromTheShelf.Remove(shoe);
							i++;
							Console.WriteLine(shoe);
						}
					}
				}
				if (totalPrice != 0)
				{
					Console.WriteLine($"Total price = {totalPrice}");
				}

				totalPrice = 0;
				Console.WriteLine("==============");
				for (int i = 0; i < shoesTakenFromTheShelf.Count; i++)
				{					
					if (copy.ElementAt(i).Number == clientNumber)
					{						
						if (i % 2 != 0)
						{
							Shoe shoe = copy.ElementAt(i);
							totalPrice += shoe.Price;
							shoesTakenFromTheShelf.Remove(shoe);
							i++;
							Console.WriteLine(shoe);
						}
					}
				}
				if (totalPrice != 0)
				{
					Console.WriteLine($"Total price = {totalPrice}");
				}

				foreach (var shoe in shoesTakenFromTheShelf)
				{
					shelf.Add(shoe);
				}
				shelf.Sort(byNumber);

				Console.WriteLine("==============");
				Console.WriteLine("Shelf");
				foreach (var shoe in shelf)
				{					
					Console.WriteLine(shoe);
				}
			}
		}
	}
}
