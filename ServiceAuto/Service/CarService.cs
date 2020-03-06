using ServiceAuto.Domain;
using ServiceAuto.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceAuto.Service
{
    class CarService
    {
        private CarRepository repository;

        /// <summary>
        /// Instantiates a car service.
        /// </summary>
        /// <param name="repository"> The repository used by the service. </param>
        public CarService(CarRepository repository)
        {
            this.repository = repository;
        }

        public void EnterRepairShop(int id, int standNumber, string licensePlate, uint numberOfDays)
        {
            // we ensure that the stand is not occupied.
            List<Car> allCars = repository.getAll();
            Car verifyCar = allCars.Find(c => c.StandNumber == standNumber);
            if (verifyCar != null && !verifyCar.LeftService)
            {
                throw new RuntimeException("That stand is already taken by another car!");
            }

            Car car = new Car(id, standNumber, licensePlate, numberOfDays);
            repository.Add(car);
        }

        public void LeaveRepairShop(int standNumber, string report, double billedPrice)
        {
            // we ensure that the stand is occupied.
            List<Car> allCars = repository.getAll();
            Car verifyCar = allCars.Find(c => c.StandNumber == standNumber);
            if (verifyCar != null && !verifyCar.LeftService)
            {
                verifyCar.LeftService = true;
                verifyCar.Report = report;
                verifyCar.BilledPrice = billedPrice;
                repository.Update(verifyCar);
                return;
            }
            throw new RuntimeException("There is no car on the given stand!");
        }
    }
}
