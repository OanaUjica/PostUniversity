using Electricity_MVCProject.Model;
using Electricity_MVCProject.View;
using System;
using static System.Console;

namespace Electricity_MVCProject
{
    class Run
    {

        static void Main(string[] args)
        {
            int option = Print.PrintMenu();
            Country[] table = null;

            while (option != 0)
            {
                switch (option)
                {
                    //case 1: 
                    //    table = Model.Read.ReadFromKeyboard();
                    //    break;
                    case 1:
                        table = Model.ReadOptions.ReadFromFile();
                        Print.PrintAll(table);
                        break;
                    case 2:
                        Sort.SortAlphabetically(table);
                        Print.PrintAll(table);
                        break;
                    //case 4:
                    //    Sort.SortAfterElectricity(table);
                    //    Print.PrintAfterElectricity(table);
                    //    break;
                    default:
                        WriteLine("Wrong option! Please try again.");
                        break;
                }
                option = Print.PrintMenu();
            }
            Model.ReadOptions.ReadFromFile();
        }
    }
}
