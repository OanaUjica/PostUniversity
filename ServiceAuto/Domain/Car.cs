using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAuto.Domain
{
    class Car
    {
        public int Id { get; set; }
        public int StandNumber { get; set; }
        public string LicensePlate { get; set; }
        public uint NumberOfDays { get; set; }
        public bool LeftService { get; set; }
        public string Report { get; set; }
        public double BilledPrice { get; set; }

        public Car(int id, int standNumber, string licensePlate, uint numberOfDays, string report, double billedPrice)
        {
            this.Id = id;
            this.StandNumber = standNumber;
            this.LicensePlate = licensePlate;
            this.NumberOfDays = numberOfDays;
            this.Report = report;
            this.BilledPrice = billedPrice;
        }

        public Car(int id, int standNumber, string licensePlate, uint numberOfDays) 
            : this(id, standNumber, licensePlate, numberOfDays, "", 0.00)
        {
            this.LeftService = false;
        }

    }
}
