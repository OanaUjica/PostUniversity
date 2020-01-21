using System.Collections.Generic;


namespace Electricity_MVCProject.Model
{
    class ComparatorElectricity : IComparer<Country>
    {
        public int Compare(Country country1, Country country2)
        {
            if (country1.MonthlyProductionElectricalCurrent.Number > country2.MonthlyProductionElectricalCurrent.Number)
            {
                return -1;
            }
            else if (country1.MonthlyProductionElectricalCurrent.Number < country2.MonthlyProductionElectricalCurrent.Number)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
