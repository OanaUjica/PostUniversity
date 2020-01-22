

using System;

namespace Electricity_MVCProject.View
{
    class HeaderTable
    {
        public static void Line(int numberOfCharacters)
        {
            for (int i = 0; i < numberOfCharacters; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine();
        }

        public static void HeaderTable1()
        {
            var header = "|Country\t |Electrical curent (KWh/month)|";
            Line(48);
            Console.WriteLine(header);
            Line(48);
        }

        public static void HeaderTable2()
        {
            var header = "|Country\t|Electrical curent  (KWh/month)| %      |";
            Line(57);
            Console.WriteLine(header);
            Line(57);
        }
    }
}
