using System;

namespace Ocp.Infrastructure.Exceptions
{
    public class ParkingException : Exception
    {
        public ParkingException(string msg) : base(msg)
        {

        }
    }
}
