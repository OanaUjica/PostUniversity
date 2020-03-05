using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace ServiceAuto.Domain
{
    class CarValidator
    {
        /// <summary>
        /// Validates a car.
        /// Raises RuntimeException if there are validation errors.
        /// </summary>
        /// <param name="car"> The car to validate. </param>
        public void Validator(Car car)
        {
            string license = car.LicensePlate;
            string errors = "";

            if (license.Length != 7)
            {
                errors += "The license plate number must be 7 characters long!\n";
            }
            if (license[0] < 'A' && license[0] > 'Z') 
            {
                errors += "The license plate number must start with a capital letter!\n";
            }
            if (license[4] < 'A' && license[4] > 'Z' ||
                license[5] < 'A' && license[5] > 'Z' ||
                license[6] < 'A' && license[6] > 'Z')
            {
                errors += "The license plate number must end with 3 capital letters!";
            }

            if (!errors.Equals(""))
            {
                throw new RuntimeException(errors);
            }
        }
    }

    [Serializable]
    internal class RuntimeException : Exception
    {
        public RuntimeException(string message) : base(message)
        {
        }
    }
}
