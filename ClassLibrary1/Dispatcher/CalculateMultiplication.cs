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
