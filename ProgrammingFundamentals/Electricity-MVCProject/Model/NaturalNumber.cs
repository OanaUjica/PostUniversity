using System;
using System.Collections.Generic;
using System.Text;

namespace Electricity_MVCProject.Model
{
    class NaturalNumber
    {
        private long number;

        public NaturalNumber()
        {
            number = 0;
        }

        public NaturalNumber(long number)
        {
            if (number >= 0) this.number = number;
            else this.number = 0;
        }

        public NaturalNumber(NaturalNumber x)
        {
            if (this != x) number = x.number;
        }

        public long Number
        {
            get { return number; }
            set
            {
                if (number >= 0) this.number = value;
                else this.number = 0;
            }
        }

        public Boolean SmallerThan(NaturalNumber number)
        {
            if (Number < number.Number) return true;
            return false;
        }
    }
}
