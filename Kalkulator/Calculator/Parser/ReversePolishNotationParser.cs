using System.Collections.Generic;
using System.Linq;

namespace Kalkulator.Calculator.Parser
{
    public class ReversePolishNotationParser
    {
        private OperatorFactory _operatorFactory;
        public string ParseInput(string inputOperation)
        {
            string stackForDigits = null;
            string stackForOperators = null;
            Dictionary<char, int> operatorsValueCounter = new Dictionary<char, int>();

            for (int i = 0; i < inputOperation.Length; i++)
            {
                _operatorFactory = new OperatorFactory(inputOperation[i]);
                if (inputOperation[i] == _operatorFactory.GetOperatorKey())
                {
                    if (!operatorsValueCounter.ContainsValue(_operatorFactory.GetOperatorValue()))
                    {
                        operatorsValueCounter.Add(_operatorFactory.GetOperatorKey(), _operatorFactory.GetOperatorValue());
                        if (operatorsValueCounter.Values.ElementAt(0) > _operatorFactory.GetOperatorValue())
                        {
                            stackForDigits += operatorsValueCounter.Keys.ElementAt(0).ToString();
                            operatorsValueCounter.Remove(operatorsValueCounter.Keys.ElementAt(0));
                            stackForOperators = _operatorFactory.GetOperatorKey().ToString();
                        }
                        else
                        {

                            stackForOperators += inputOperation[i];
                        }
                    }
                    else
                    {
                        stackForDigits += stackForOperators;
                        stackForOperators = inputOperation[i].ToString();
                    }
                }
                else
                {
                    stackForDigits += inputOperation[i];
                }
            }
            var reversedStackForOperators = ReverseStack(stackForOperators);
            var output = stackForDigits + reversedStackForOperators;
            return output;
        }

        private string ReverseStack(string stackForOperators)
        {
            List<char> characterList = new List<char>();

            foreach (var source in stackForOperators.Reverse())
            {
                characterList.Add(source);
            }

            var result = ConcatOperatorsToString(characterList);
            return result;
        }

        private string ConcatOperatorsToString(List<char> input)
        {
            string result = "";
            foreach (var character in input)
            {
                result += character;
            }
            return result;
        }
    }
}