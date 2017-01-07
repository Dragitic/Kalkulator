using CalculatorLogic.Logic;

namespace CalculatorUI.Action
{
    public class Calculator: ICalculator
    {
        private PostfixParser _postfixParser;
        private PostfixCalculator _postfixCalculator;
        public string DoCalculation(string expressionToCaluclate)
        {
            _postfixParser = new PostfixParser();
            _postfixCalculator = new PostfixCalculator();

            var result = _postfixParser.TryParse(expressionToCaluclate);
            return _postfixCalculator.Calculate(result);
        }
    }
}
