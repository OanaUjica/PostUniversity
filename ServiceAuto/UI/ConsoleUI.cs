using ServiceAuto.Domain;
using ServiceAuto.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAuto.UI
{
    class ConsoleUI
    {
        private CarService _carService;

        public ConsoleUI(CarService carService)
        {
            _carService = carService;
        }

        public void runUserInterface()
        {
            while (true)
            {
                showMenu();

                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    handleEntry();
                }
                else if (option == 2)
                {
                    handleExit();
                }
                else if (option == 3)
                {
                    //handleReport();
                }
                else if (option == 0)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }

            }
        }

        private void handleEntry()
        {
            Console.WriteLine("Entry id: ");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Stand number: ");
            int standNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("License plate number: ");
            string licensePlate = Console.ReadLine();

            Console.WriteLine("Number of days: ");
            uint numberOfDays = uint.Parse(Console.ReadLine());

            try
            {
                _carService.EnterRepairShop(id, standNumber, licensePlate, numberOfDays);
                Console.WriteLine("Car entered repair shop successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("We have errors:");
                Console.WriteLine(e.Message);
            }
        }

        private void handleExit()
        {
            Console.WriteLine("Stand number: ");
            int standNumber = int.Parse(Console.ReadLine());

            Console.WriteLine("Report: ");
            string report = Console.ReadLine();

            Console.WriteLine("Billed price: ");
            double billedPrice = double.Parse(Console.ReadLine());

            try
            {
                _carService.LeaveRepairShop(standNumber, report, billedPrice);
                Console.WriteLine("Car left repair shop successfully!");
            }
            catch (Exception e)
            {
                Console.WriteLine("We have errors:");
                Console.WriteLine(e.Message);
            }
        }

        private void handleReport()
        {
            

        }


        private void showMenu()
        {
            Console.WriteLine("1. Add car to repair shop.");
            Console.WriteLine("2. Remove car from repair shop.");
            Console.WriteLine("3. Show stands report.");
            Console.WriteLine("0. Exit.");
            Console.WriteLine("Your option: ");
        }
    }
}
