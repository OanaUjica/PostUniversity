using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Electricity_MVCProject.Model
{
    class ReadOptions
    {
                
        /// <summary>
        /// Read line by line a text file, every line represents a country with the annual production of electricity.
        /// </summary>
        /// <returns> An array with all the countries and their annual production. </returns> 
        public static Country[] ReadFromFile()
        {
            int numberOfLines;
            Country[] countries = null;

            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\USER\Desktop\Work\PUModule2JavaIntro\CurentElectric-homework\Country.txt"))
                {
                    var line = sr.ReadLine();
                    numberOfLines = int.Parse(line);
                    
                    countries = new Country[numberOfLines];

                    var i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //bool isParsable = int.TryParse(line, out numberOfLines);
                        //if (!isParsable) Console.WriteLine("Please enter a number equal with the number of countries!");
                        //Console.WriteLine($"number of lines = {numberOfLines}");                        
                        var categories = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                        var name = categories[0];
                        var monthlyProcent = int.Parse(categories[1]);

                        countries[i] = new Country();
                        countries[i].Name = name;
                        countries[i].ProcentFromTotalElectricalCurrent = monthlyProcent;

                        i++;
                    }
                }                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            return countries;
        }

        /// <summary>
        /// Read from the keyboard the country with the annual production of electricity.
        /// </summary>
        /// <returns> An array with all the countries and their annual production. </returns> 
        public static Country[] ReadFromKeyboard()
        {
            var length = ReadInteger("Enter the number of countries:");
            var countries = new Country[length];

            for (int i = 0; i < countries.Length; i++)
            {
                countries[i] = new Country();

                var name = ReadString("Country name:");
                countries[i].Name = name;

                var electricity = ReadLong("Production of electricity:");
                countries[i].MonthlyProductionElectricalCurrent.Number = electricity;
            }
            return countries;
        }

        /// <summary>
        /// Method used to read a string of characters.
        /// </summary>
        /// <param name="line"></param>
        /// <returns> The string. </returns>
        public static String ReadString (String line)
        {
            try
            {
                Console.WriteLine(line);
                return Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input! Enter a string of characters. Please try again.");
                return ReadString(line);                
            }
        }

        /// <summary>
        /// Method used to read an integer number.
        /// </summary>
        /// <param name="line"></param>
        /// <returns> The integer. </returns>
        public static int ReadInteger(String line)
        {
            try
            {
                Console.WriteLine(line);
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input! Enter an integer number. Please try again.");
                return ReadInteger(line);
            }
        }

        /// <summary>
        /// Method used to read a long number.
        /// </summary>
        /// <param name="line"></param>
        /// <returns> The long number. </returns>
        public static long ReadLong(String line)
        {
            try
            {
                Console.WriteLine(line);
                return long.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Wrong input! Enter a long number. Please try again.");
                return ReadLong(line);
            }
        }
    }
}
