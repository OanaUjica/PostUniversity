using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity_MVCProject.Model
{
    class Country
    {
        private string name = null;
        private NaturalNumber monthlyProductionElectricalCurrent = null;
        private double procentFromTotalElectricalCurent = 0.0;

        public Country()
        {

        }
        public Country(string Name, long monthlyProduction)
        {
            this.name = Name;
            this.monthlyProductionElectricalCurrent = new NaturalNumber(monthlyProduction);
        }

        public string Name { get; set; }
        public NaturalNumber MonthlyProductionElectricalCurrent { get; set; }
        public long ProcentFromTotalElectricalCurrent { get; set; }

        public Boolean SmallerNameThan(Country country)
        {
            if (this.Name.CompareTo(country.Name) < 0) return true;
            return false;
        }

        public Boolean SmallerMonthlyProductionThan(Country country)
        {
            if (this.ProcentFromTotalElectricalCurrent.CompareTo(country.ProcentFromTotalElectricalCurrent) < 0) return true;
            return false;
        }
    }
}
