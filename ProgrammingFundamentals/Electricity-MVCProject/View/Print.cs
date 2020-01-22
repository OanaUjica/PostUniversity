using Electricity_MVCProject.Model;
using System;
using static System.Console;

namespace Electricity_MVCProject.View
{
    class Print
    {
        public static int PrintMenu()
        {
            WriteLine();
            WriteLine("1. Read data (file)");
            WriteLine("2. Read data (keyboard)");
            WriteLine("3. Print initial table");
            WriteLine("4. Print alphabetically");
            WriteLine("5. Print after monthly production");
            WriteLine("0. Program ending");
            return ReadOptions.ReadInteger("Choose an option: ");
        }


        public static void InitialPrint(Country[] table)
        {
            HeaderTable.HeaderTable1();
            for (int i = 0; i < table.Length; i++)
            {
                WriteLine($"|{table[i].Name,-15}|{table[i].MonthlyProductionElectricalCurrent.Number.ToString(),30}|");
            }
            HeaderTable.Line(48);
        }
        

        public static void PrintSortedAlphabetically(Country[] table)
        {
            Sort.SortAlphabetically(table);
            InitialPrint(table);
        }



        public static void PrintElectricity(Country[] table) 
        {
            HeaderTable.HeaderTable2();
            long totalProductionElectricity = 0;
            double procent = 0.0;
            for (int i = 0; i < table.Length; i++)
            {
                totalProductionElectricity += table[i].MonthlyProductionElectricalCurrent.Number;
            }

            for (int i = 0; i < table.Length; i++)
            {
                procent = table[i].CalculateProcentFromTotalElectricalCurent(totalProductionElectricity);
                Console.WriteLine($"|{table[i].Name,-14}|{table[i].MonthlyProductionElectricalCurrent.Number.ToString(),31}|{procent.ToString("F"),-8}|");
            }
            HeaderTable.Line(57);
            Console.WriteLine($"\t\t\tTotal: {totalProductionElectricity}");
        }
        public static void PrintSortedElectricity(Country[] table)
        {
            Sort.SortAfterElectricity(table);
            PrintElectricity(table);
        }



    }
}
