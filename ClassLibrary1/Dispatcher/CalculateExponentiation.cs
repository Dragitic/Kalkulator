namespace CalculatorLogic.Dispatcher
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