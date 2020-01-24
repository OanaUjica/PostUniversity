using System;
using System.Collections.Generic;
using System.Text;

namespace ShoeShop
{
    class Database
    {
		

		/// <summary>
		/// Database with all the initial shoes stored in the shop, sorted by number.
		/// </summary>
		public static List<Shoe> InitializeDatabase()
		{
			SortAscendingShoesNumbers byNumber = new SortAscendingShoesNumbers();
			List<Shoe> shelf = new List<Shoe>();

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

			shelf.Add(shoe1);
			shelf.Add(shoe12);
			shelf.Add(shoe3);
			shelf.Add(shoe4);
			shelf.Add(shoe5);
			shelf.Add(shoe6);
			shelf.Add(shoe10);
			shelf.Add(shoe8);
			shelf.Add(shoe9);
			shelf.Add(shoe7);
			shelf.Add(shoe11);
			shelf.Add(shoe2);
			shelf.Add(shoe13);

			shelf.Sort(byNumber);
			return shelf;
		}
	}
}
