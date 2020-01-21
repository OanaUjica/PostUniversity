

using System;

namespace Electricity_MVCProject.View
{
    class HeaderTable
    {
        public static void Line(int numberOfCharacters)
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Console.WriteLine("=");
            }
            Console.WriteLine();
        }

        public static void HeaderTable1()
        {
            var header = "|Country\t \t|Electrical curent (KWh/month)|";
            Line(46);
            Console.WriteLine(header);
            Line(46);
        }

        public static void HeaderTable2()
        {
            var header = "|Country\t \t|Electrical curent  (KWh/month)| %      |";
            Line(55);
            Console.WriteLine(header);
            Line(55);
        }
    }
}
