﻿using Electricity_MVCProject.Model;
using Electricity_MVCProject.View;
using System;
using static System.Console;

namespace Electricity_MVCProject
{
    class Run
    {
        public static int ReadInteger(string prompter)
        {
            WriteLine(prompter);
            try
            {
                int number = int.Parse(ReadLine());
                return number;
            }
            catch (Exception e)
            {
                WriteLine("Wrong option! Please try again.");
                ReadInteger(prompter);
            }
            return 0;
        }

        public static int Menu()
        {
            WriteLine();
            //WriteLine("1. Read data (keyboard)");
            WriteLine("1. Read data (file)");
            WriteLine("2. Print alphabetically");
            //WriteLine("4. Print after monthly production");
            WriteLine("0. Program ending");
            return ReadInteger("Choose an option: ");
        }

        static void Main(string[] args)
        {
            int option = Menu();
            Country[] table = null;

            while (option != 0)
            {
                switch (option)
                {
                    //case 1: 
                    //    table = Model.Read.ReadFromKeyboard();
                    //    break;
                    case 1:
                        table = Model.Read.ReadFromFile();
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
                option = Menu();
            }
            Model.Read.ReadFromFile();
        }
    }
}