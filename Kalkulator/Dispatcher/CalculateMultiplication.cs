using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Dispatcher
{
    public class CalculateMultiplication : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            return firstValue * secondValue;
        }
    }
}
