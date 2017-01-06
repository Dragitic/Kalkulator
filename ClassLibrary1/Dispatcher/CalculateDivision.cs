namespace Kalkulator.Dispatcher
{
    public class CalculateDivision : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            return firstValue / secondValue;
        }
    }
}
