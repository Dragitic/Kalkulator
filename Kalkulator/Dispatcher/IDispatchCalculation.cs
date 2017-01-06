using System.Collections;
using System.Collections.Generic;
using Calculator;

namespace Kalkulator.Dispatcher
{
    internal interface IDispatchCalculation
    {
        double DoAction(double firstValue, double secondValue);
    }
}