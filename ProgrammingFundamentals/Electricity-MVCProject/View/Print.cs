using Electricity_MVCProject.Model;
using System;
using static System.Console;

namespace Electricity_MVCProject.View
{
    class Print
    {
        public static string ReadString(string str)
        {
            try
            {
                WriteLine(str);
                string s = ReadLine();
                return s;
            }
            catch (Exception e)
            {
                WriteLine("Wrong input! Please try again.");
                return ReadString(str);
            }
        }

        public static void HeaderTableAlpha()
        {
            string header = "|Country       |Monthly production |";
            string lines = "====================================";
            WriteLine(lines);
            WriteLine(header);
            WriteLine(lines);
        }

        public static void PrintAll(Country[] table)
        {
            HeaderTableAlpha();

            for (int i = 0; i < table.Length; i++)
            {
                string[] s = new string[2];
                s[0] = table[i].Name;
                long monthlyProduction = table[i].ProcentFromTotalElectricalCurrent;
                s[1] = monthlyProduction.ToString();

                WriteLine($"|{s[0],-14}|{s[1],-19}|");
            }
        }
        

        public static void PrintAfterElectricity(Country[] table)
        {
            Country[] unsortedTable = null;

        }
    }
}
