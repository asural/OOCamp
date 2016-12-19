using System;
using System.Collections.Generic;
using Ocp.Infrastructure.Exceptions;

namespace Ocp.CarParking
{
    public class ParkingBoy
    {
        private int _capacity = 10;

        public int Capacity
        {
            get { return _capacity; }
            set { _capacity = value; }
        }

        public void DepositCar(Car car)
        {
            foreach (var lot in ParkingLots)
            {
                try
                {
                    lot.DepositCar(car);
                    return;
                }
                catch
                {
                    // ignored
                }
            }

            throw new ParkingException("车位已满，无法再存车");
        }

        public Car WithDrawCar(Car car)
        {
            foreach (var lot in ParkingLots)
            {
                try
                {
                    return lot.WithDrawCar(car);
                }
                catch
                {
                    // ignored
                }
            }

            throw new ParkingException("找不到车");
        }
    
public  List<ParkingLot> ParkingLots { get; set; }}
}
