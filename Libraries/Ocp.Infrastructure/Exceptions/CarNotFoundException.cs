using System;

namespace Ocp.Infrastructure.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException(string msg) : base(msg)
        {

        }
    }
}