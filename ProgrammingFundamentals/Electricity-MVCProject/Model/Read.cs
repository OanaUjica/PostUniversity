using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Electricity_MVCProject.Model
{
    class Read
    {
        public static Country[] ReadFromFile()
        {
            int numberOfLines;
            Country[] countries = null;

            try
            {
                using (StreamReader sr = new StreamReader(@"C:\Users\USER\Desktop\Work\PUModule2JavaIntro\CurentElectric-homework\Country.txt"))
                {
                    string line = sr.ReadLine();
                    numberOfLines = int.Parse(line);
                    
                    countries = new Country[numberOfLines];

                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        //bool isParsable = int.TryParse(line, out numberOfLines);
                        //if (!isParsable) Console.WriteLine("Please enter a number equal with the number of countries!");
                        //Console.WriteLine($"number of lines = {numberOfLines}");                        
                        string[] categories = line.Split(",", StringSplitOptions.RemoveEmptyEntries);
                        string name = categories[0];
                        int monthlyProcent = int.Parse(categories[1]);

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


        public static Country[] ReadFromKeyboard()
        {
            Country[] countries = null;
            return countries;
        }
    }
}
