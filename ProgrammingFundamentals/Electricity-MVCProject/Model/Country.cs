using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity_MVCProject.Model
{
    class Country
    {
        private string name = null;
        private NaturalNumber monthlyProductionElectricalCurrent = null;
        private double procentFromTotalProduction = 0.0;

        public Country()
        {

        }
        public Country(string name, long monthlyProduction)
        {
            this.name = name;
            this.monthlyProductionElectricalCurrent = new NaturalNumber(monthlyProduction);
        }

        public string Name { get; set; }
        public NaturalNumber MonthlyProductionElectricalCurrent { get; set; }
        public double ProcentFromTotalProduction { get; set; }

        public Boolean SmallerNameThan(Country country)
        {
            if (this.Name.CompareTo(country.Name) < 0) return true;
            return false;
        }

        public double CalculateProcentFromTotalElectricalCurent(long total)
        {
            this.procentFromTotalProduction = ((double)100 * this.MonthlyProductionElectricalCurrent.Number) / total;
            return procentFromTotalProduction;
        }
    }
}
