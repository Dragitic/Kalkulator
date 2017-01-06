using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.Dispatcher
{
    public class CalculateExponentiation : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            double result = 1;
            for (var i = 0; i < secondValue; i++)
            {
                result *= firstValue;
            }
            return result;
        }
    }
}
