namespace CalculatorLogic.Dispatcher
{
    public class CalculateAddition : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            return firstValue + secondValue;
        }
    }
}
