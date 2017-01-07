using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CalculatorLogic.Dispatcher;

namespace CalculatorLogic.Logic
{
    public class PostfixCalculator
    {
        private readonly Stack<double> _numbersList;

        private double _numbersToParse;
        private double _firstCalculationValue = 0;
        private double _secondCalculationValue = 0;
        private double _resultCalculationValue = 0;

        private string _inputCharacter = "";
        private bool _firstValueIsNegativeNumber;
        public PostfixCalculator()
        {
            _numbersList = new Stack<double>();
        }
        public string Calculate(string inputExpression)
        {
            for (var position = 0; position < inputExpression.Length; position++)
            {
                switch (inputExpression[position])
                {
                    case '^':
                        PostfixCalculationData();
                        _resultCalculationValue = new CalculateExponentiation().DoAction(_firstCalculationValue, _secondCalculationValue);
                        AddNewValueToStack();
                        break;
                    case '*':
                        PostfixCalculationData();
                        _resultCalculationValue = new CalculateMultiplication().DoAction(_firstCalculationValue, _secondCalculationValue);
                        AddNewValueToStack();
                        break;
                    case '/':
                        PostfixCalculationData();
                        _resultCalculationValue = new CalculateDivision().DoAction(_firstCalculationValue, _secondCalculationValue);
                        AddNewValueToStack();
                        break;
                    case '+':
                        PostfixCalculationData();
                        _resultCalculationValue = new CalculateAddition().DoAction(_firstCalculationValue, _secondCalculationValue);
                        AddNewValueToStack();
                        break;
                    case '-':
                        PostfixCalculationData();
                        _resultCalculationValue = new CalculateSubstraction().DoAction(_firstCalculationValue, _secondCalculationValue);
                        AddNewValueToStack();
                        break;
                    case '#':
                        break;
                    default:
                        _inputCharacter += inputExpression[position];
                        AddNumberToStack(inputExpression, position);
                        break;
                }
            }
            return ParseExpressionResultToString();
        }

        private void AddNumberToStack(string inputExpression, int position)
        {
            var result = CheckHashtagPosition(inputExpression, position);
            var foo = inputExpression[result];
            if (inputExpression[result] != '#' || !StoreInputNumbers())
            {
                
            }
            else
            {
                _numbersList.Push(_numbersToParse);
                _inputCharacter = "";
            }
        }

        private static int CheckHashtagPosition(string inputExpression, int position)
        {
            int result;
            if (inputExpression.Length - 1 == position)
                result = position;
            else
                result = position + 1;
            return result;
        }

        private bool StoreInputNumbers()
        {
            return double.TryParse(_inputCharacter, out _numbersToParse);
        }

        private void AddNewValueToStack()
        {
            PopUpNumbersAndOperator();
            _numbersList.Push(_resultCalculationValue);
        }

        private void PostfixCalculationData()
        {
            if (_numbersList.Count >= 2)
            {
                _firstCalculationValue = _numbersList.ElementAt(1);
                _secondCalculationValue = _numbersList.ElementAt(0);
                _firstValueIsNegativeNumber = false;
            }
            else
            {
                _secondCalculationValue = _numbersList.ElementAt(0);
                _firstValueIsNegativeNumber = true;
            }
        }

        private void PopUpNumbersAndOperator()
        {
            var iterator = 0;
            if(_firstValueIsNegativeNumber)
                return;
            while (iterator < 2)
            {
                _numbersList.Pop();
                iterator++;
            }
        }
        private string ParseExpressionResultToString()
        {
            var value = _numbersList.ElementAt(0);
            var result = Math.Round(value, 3);
            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
