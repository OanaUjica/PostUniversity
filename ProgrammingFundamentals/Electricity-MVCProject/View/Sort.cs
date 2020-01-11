using Electricity_MVCProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity_MVCProject.View
{
    class Sort
    {
        public static void SortAlphabetically(Country[] table)
        {
            for (int i = 0; i < table.Length-1; i++)
            {
                for (int j = i+1; j < table.Length; j++)
                {
                    if (!table[i].SmallerNameThan(table[j]))
                    {
                        Country aux = table[i];
                        table[i] = table[j];
                        table[j] = aux;
                    }
                }
            }
        }

        public static Country[] SortAfterElectricity(Country[] table)
        {
            Country[] unsortedTable = null;
            return unsortedTable;
        } 
    }
}
