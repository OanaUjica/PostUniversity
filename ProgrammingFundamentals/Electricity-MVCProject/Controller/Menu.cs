using Electricity_MVCProject.Model;
using Electricity_MVCProject.View;
using System;

namespace Electricity_MVCProject.Controller
{
    class Menu
    {
        public static void Options()
        {
            int option = Print.PrintMenu();
            Country[] table = null;

            while (option != 0)
            {
                switch (option)
                {
                    case 1:
                        table = ReadOptions.ReadFromFile();
                        break;
                    case 2:
                        table = ReadOptions.ReadFromKeyboard();
                        break;
                    case 3:
                        if (table != null) Print.InitialPrint(table);
                        else Console.WriteLine("You didn't read the data from the file or keyboard");
                        break;
                    case 4:
                        Print.PrintSortedAlphabetically(table);
                        break;
                    case 5:
                        Print.PrintSortedElectricity(table);
                        break;
                    default:
                        Console.WriteLine("Wrong option! Please try again.");
                        break;
                }
                option = Print.PrintMenu();
            }
            Console.WriteLine("Program ended");
        }

    }
}
