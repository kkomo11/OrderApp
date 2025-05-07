using System;

namespace OrderApp
{
    public class SpyOrderLogger : IOrderLogger
    {
        public bool WasCalled { get; private set; } = false;

        public void ShowOrderLog(Order order)
        {
            WasCalled = true;
        }
    }
}
