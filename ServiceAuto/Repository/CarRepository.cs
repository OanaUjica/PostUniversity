using ServiceAuto.Domain;
using System;
using System.Collections.Generic;
using System.Text;


namespace ServiceAuto.Repository
{
    class CarRepository
    {
        private List<Car> cars = new List<Car>();
        private CarValidator validator;

        /// <summary>
        /// Instantiates a repository.
        /// </summary>
        /// <param name="validator"> The validator used by this repository. </param>
        public CarRepository(CarValidator validator)
        {
            this.validator = validator;
        }

        /// <summary>
        /// Find a car.
        /// </summary>
        /// <param name="id"> The id used to find a car. </param>
        /// <returns></returns>
        private Car FindById(int id)
        {
            Car car = cars.Find(c => c.Id == id);
            if (car != null)
            {
                return car;
            }
            return null;
        }

        /// <summary>
        /// Adds a car to the repository.
        /// Raises RuntimeException if there already is a car with the given id or the car fails validation.
        /// </summary>
        /// <param name="car"> The car to add. </param>
        public void Add(Car car)
        {
            if (FindById(car.Id) != null)
            {
                throw new RuntimeException("A car with that ID already exists!");
            }

            validator.Validator(car);
            cars.Add(car);
        }

        /// <summary>
        /// Updates an existing car.
        /// Raises RuntimeException if there is no car with car's id or the new car fails validation.
        /// </summary>
        /// <param name="car"> The car to be updated. </param>
        public void Update(Car car)
        {
            Car existingCar = FindById(car.Id);
            if (existingCar == null)
            {
                throw new RuntimeException("There is no car with the given ID");
            }

            validator.Validator(car);
            existingCar.StandNumber = car.StandNumber;
            existingCar.LicensePlate = car.LicensePlate;
            existingCar.NumberOfDays = car.NumberOfDays;
            existingCar.Report = car.Report;
            existingCar.BilledPrice = car.BilledPrice;            
        }

        /// <summary>
        /// Gets the list of cars.
        /// </summary>
        /// <returns> All cars in the repository. </returns>
        public List<Car> getAll()
        {
            return cars;
        }
    }
}
