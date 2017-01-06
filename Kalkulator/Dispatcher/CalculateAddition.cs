using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;

namespace Kalkulator.Dispatcher
{
    public class CalculateAddition : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }
    }
}
