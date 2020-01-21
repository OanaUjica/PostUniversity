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
            WriteLine("1. Read data (keyboard)");
            WriteLine("1. Read data (file)");
            WriteLine("2. Print alphabetically");
            WriteLine("4. Print after monthly production");
            WriteLine("0. Program ending");
            return ReadOptions.ReadInteger("Choose an option: ");
        }


        public static void PrintAll(Country[] table)
        {
            HeaderTable.HeaderTable1();

            for (int i = 0; i < table.Length; i++)
            {
                WriteLine($"|{table[i].Name,-14}|{table[i].MonthlyProductionElectricalCurrent.Number.ToString(),-19}|");
            }
        }
        

        public static void PrintAfterElectricity(Country[] table)
        {
            Country[] unsortedTable = null;

        }
    }
}
