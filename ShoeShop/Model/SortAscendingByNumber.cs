using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace ShoeShop.Model
{
    class SortAscendingByNumber : IComparer<Shoe>
    {
        public int Compare(Shoe shoe1, Shoe shoe2)
        {
            if (shoe1.Number < shoe2.Number)
            {
                return -1;
            }
            else if (shoe1.Number > shoe2.Number)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
