using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoeShop
{
    class Shop
    {
        private List<Shoe> shoes;
        SortAscendingShoesNumbers byNumber = new SortAscendingShoesNumbers();

		/// <summary>
		/// Database with all the initial shoes stored in the shop, sorted by number.
		/// </summary>
        public void Database()
        {
            var shoe1 = new Shoe(34, "green", 50);
			var shoe2 = new Shoe(34, "gray", 32);

			var shoe3 = new Shoe(35, "black", 35);
			var shoe4 = new Shoe(35, "black", 10);
			var shoe5 = new Shoe(35, "red", 71);

			var shoe6 = new Shoe(36, "gray", 13);
			var shoe7 = new Shoe(36, "green", 43);
			var shoe8 = new Shoe(36, "black", 39);
			var shoe9 = new Shoe(36, "black", 32);

			var shoe10 = new Shoe(37, "black", 15);
			var shoe11 = new Shoe(37, "green", 43);

			var shoe12 = new Shoe(38, "black", 33);
			var shoe13 = new Shoe(38, "black", 27);

			this.shoes = new List<Shoe>();
			shoes.Add(shoe1);
			shoes.Add(shoe12);
			shoes.Add(shoe3);
			shoes.Add(shoe4);
			shoes.Add(shoe5);
			shoes.Add(shoe6);
			shoes.Add(shoe10);
			shoes.Add(shoe8);
			shoes.Add(shoe9);
			shoes.Add(shoe7);
			shoes.Add(shoe11);
			shoes.Add(shoe2);
			shoes.Add(shoe13);

			shoes.Sort(byNumber);
		}

		/// <summary>
		/// Add a new pair of shoes in the shop and sort the the shoes after their number.
		/// </summary>
		/// <param name="shoe"></param>
		public void Add(Shoe shoe)
		{
			shoes.Add(shoe);
			shoes.Sort(byNumber);
		}

		/// <summary>
		/// Verify is the offer of shoes in balanced or not.
		/// </summary>
		/// <returns></returns>
		public Boolean isABalancedOffer()
		{
			int minNumber = int.MaxValue;
			int maxNumber = int.MinValue;
			foreach (var shoe in shoes)
			{
				if (shoe.Number < minNumber) minNumber = shoe.Number;
				if (shoe.Number > maxNumber) maxNumber = shoe.Number;
			}

			int minStock = int.MaxValue;
			int maxStock = int.MinValue;
			int count = 0;
			for (int i = minNumber; i <= maxNumber; i++)
			{
				foreach (var shoe in shoes)
				{
					if (shoe.Number == i) count++;
				}

				if (count < minStock) minStock = count;
				if (count > maxStock) maxStock = count;
				count = 0;
			}

			Console.WriteLine($"Min = {minStock}");
			Console.WriteLine($"Max = {maxStock}");

			if (maxStock - minStock <= 3) return true;
			else return false;
		}

		/// <summary>
		/// Print the total price that the client will pay for the selected shoes and the list of shoes left on the shelf.
		/// </summary>
		public void Client()
		{
			Random randomIndex1 = new Random();
			int indexShoe1 = randomIndex1.Next(0, shoes.Count);
			Random randomIndex2 = new Random();
			int indexShoe2 = randomIndex2.Next(0, shoes.Count);

			List<Shoe> shoesTakenFromTheShelf = new List<Shoe>();
			if (indexShoe1 < indexShoe2)
			{
				for (int i = indexShoe1; i <= indexShoe2; i++)
				{
					Shoe randomShoe = shoes.ElementAt(indexShoe1);
					shoesTakenFromTheShelf.Add(randomShoe);
					shoes.RemoveAt(indexShoe1);
				}

				uint totalPrice = 0;
				List<Shoe> copy = new List<Shoe>();
				foreach (var shoe in shoesTakenFromTheShelf)
				{
					copy.Add(shoe);
				}

				int clientNumber = 36;
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
					shoes.Add(shoe);
				}
				shoes.Sort(byNumber);

				foreach (var shoe in shoes)
				{					
					Console.WriteLine(shoe);
				}
			}
		}
	}
}
