namespace CalculatorLogic.Dispatcher
{
    public class CalculateSubstraction : IDispatchCalculation
    {
        public double DoAction(double firstValue, double secondValue)
        {
            return firstValue - secondValue;
        }
    }
}
