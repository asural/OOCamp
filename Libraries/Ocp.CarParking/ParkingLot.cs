using System.Collections.Generic;
using Ocp.Infrastructure.Exceptions;

namespace Ocp.CarParking
{
    public class ParkingLot
    {
        private int _capacity = 10;
        public int Capacity { get { return _capacity; } set { _capacity = value; } }
        


        private readonly IList<Car> _cars = new List<Car>();

        public void DepositCar(Car car)
        {
            if (_capacity < 1)
            {
                throw new ParkingException("车位已满，无法再存车");
            }
            _cars.Add(car);
            _capacity--;
        }

        public Car WithDrawCar(Car car)
        {
            if (!_cars.Contains(car))
            {
                throw new CarNotFoundException("找不到该车");
            }
            _cars.Remove(car);
            _capacity++;
            return car;
        }
    }
}
