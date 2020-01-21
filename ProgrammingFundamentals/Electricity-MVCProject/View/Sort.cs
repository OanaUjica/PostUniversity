using Electricity_MVCProject.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity_MVCProject.View
{
    class Sort
    {
        /// <summary>
        /// Sort table alphabetically after the names fo the countries.
        /// </summary>
        /// <param name="table"></param>
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

        /// <summary>
        /// Sort table descending after the production of electricity using class ComparatorElectricity
        /// </summary>
        /// <param name="table"></param>
        public static void SortAfterElectricity(Country[] table)
        {
            ComparatorElectricity comparatorElectricity = new ComparatorElectricity();
            Array.Sort(table, comparatorElectricity);
        } 
    }
}
