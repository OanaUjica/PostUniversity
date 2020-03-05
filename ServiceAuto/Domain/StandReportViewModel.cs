using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAuto.Domain
{
    class StandReportViewModel
    {
        public int StandNumber { get; set; }
        public double PriceAverage { get; set; }

        public StandReportViewModel(int standNumber, double priceAverage)
        {
            this.StandNumber = standNumber;
            this.PriceAverage = priceAverage;
        }
    }
}
