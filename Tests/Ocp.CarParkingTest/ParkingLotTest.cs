using Ocp.CarParking;
using Ocp.Infrastructure.Exceptions;
using Xunit;

namespace Ocp.CarParkingTest
{
    public class ParkingLotTest
    {
        [Fact(DisplayName = "存车_车位量足够=>存入后可以取出")]
        public void 存车_车位量足够()
        {
            //Given
            var p = new ParkingLot();
            var car = new Car();
            //When
            p.DepositCar(car);
            //Then
            var car1 = p.WithDrawCar(car);
            Assert.Equal(car, car1);
        }

        [Fact(DisplayName = "存车_车位量不够=>异常，无法存车")]
        public void 存车_车位量不够()
        {
            //Given
            var p = new ParkingLot();
            var car = new Car();
            for (var j = 0; j < 10; j++)
            {
                p.DepositCar(car);
            }

            Assert.Throws<ParkingException>(() => p.DepositCar(car));
        }

        [Fact(DisplayName = "取车_尚未存车=>异常，无法取车")]
        public void 取车_尚未存车()
        {
            //Given
            var p = new ParkingLot();
            var car = new Car();

            //Then
            Assert.Throws<CarNotFoundException>(() =>
            {
                //When
                p.WithDrawCar(car);
            });
        }

        [Fact(DisplayName = "取车_不提供票据=>异常，无法取车")]
        public void 取车_不提供票据()
        {
            //Given
            var p = new ParkingLot();
            var car = new Car();
            p.DepositCar(car);

            //Then
            Assert.Throws<CarNotFoundException>(() =>
            {
                //When
                p.WithDrawCar(null);
            });
        }

        [Fact(DisplayName = "剩余车位量_车位量足够_存一辆车=>减一")]
        public void 剩余车位量_车位量足够_存一辆车()
        {
            //given
            var p = new ParkingLot();
            var capacity = p.Capacity;
            //when
            p.DepositCar(new Car());
            //then
            var lastestCapacity = p.Capacity;
            Assert.Equal(capacity - 1, lastestCapacity);
        }

        [Fact(DisplayName = "剩余车位量_车位量不够_存一辆车=>不变")]
        public void 剩余车位量_车位量不够_存一辆车()
        {
            //given
            var p = new ParkingLot();
            for (var i = 0; i < 10; i++)
            {
                p.DepositCar(new Car());
            }
            var capacity = p.Capacity;
            //when
            try
            {
                p.DepositCar(new Car());
            }
            catch
            {
                // ignored
            }
            //then
            var lastestCapacity = p.Capacity;
            Assert.Equal(capacity, lastestCapacity);
        }

        [Fact(DisplayName = "剩余车位量_取一辆车=>加一")]
        public void 剩余车位量_取一辆车()
        {
            //given
            var p = new ParkingLot();
            var car = new Car();
            p.DepositCar(car);
            var capacity = p.Capacity;
            //when
            p.WithDrawCar(car);
            //then
            var lastestCapacity = p.Capacity;
            Assert.Equal(capacity + 1, lastestCapacity);
        }
    }
}
