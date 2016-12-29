using System.Collections.Generic;
using System.Linq;

namespace Kalkulator
{
    public class PostfixParser
    {

        private readonly Operators _addition;
        private readonly Operators _subtraction;
        private readonly Operators _multiplication;
        private readonly Operators _division;
        private readonly Operators _leftParenthesis;
        private readonly Operators _rightParenthesis;

        private Stack<Operators> _operatorsStack;
        private Stack<Operators> _operatorsStackForParenthesis;

        private string _postfixString;
        private string _postfixParenthesisString;
        private string _postfixFinalString;

        public PostfixParser()
        {
            _addition = new Operators() { Token = '+', Value = 1 };
            _subtraction = new Operators() { Token = '-', Value = 1 };
            _multiplication = new Operators() { Token = '*', Value = 2 };
            _division = new Operators() { Token = '/', Value = 2 };
            _leftParenthesis = new Operators() { Token = '(', Value = 9 };
            _rightParenthesis = new Operators() { Token = ')', Value = 9 };
        }
        public string TryParse(string expression)
        {
            var mainExpression = expression;
            _operatorsStack = new Stack<Operators>();
            _operatorsStackForParenthesis = new Stack<Operators>();

            ExpressionActionCreator(mainExpression);
            _postfixFinalString = AddOperatorsFromStackToPostfixString(_postfixString);

            return RemoveParenthesisFromExpression(_postfixFinalString);
        }

        private static string RemoveParenthesisFromExpression(string expression)
        {
            return expression.Where(e => e != '(' && e != ')').Aggregate("", (current, e) => current + e);
        }

        private void ExpressionActionCreator(string expression)
        {
            foreach (var t in expression)
            {
                switch (t)
                {
                    case '*':
                        CheckPrecendese(_multiplication);
                        break;
                    case '/':
                        CheckPrecendese(_division);
                        break;
                    case '+':
                        CheckPrecendese(_addition);
                        break;
                    case '-':
                        CheckPrecendese(_subtraction);
                        break;
                    case '(':
                        CheckPrecendese(_leftParenthesis);
                        break;
                    case ')':
                        CheckPrecendese(_rightParenthesis);
                        break;
                    default:
                        WriteNonOperatorToPostfixString(t);
                        break;
                }
            }
        }

        private void WriteNonOperatorToPostfixString(char t)
        {
            if (_operatorsStackForParenthesis.Count > 0)
            {
                _postfixParenthesisString += t;
            }
            else
            {
                _postfixString += t;
            }
        }

        private void CheckPrecendese(Operators expressionOperator)
        {
            if (_operatorsStackForParenthesis.Count > 0)
            {
                if (expressionOperator.Token == ')')
                {
                    PushParenthesisTokensFromStack();
                    _postfixString += _postfixParenthesisString;
                    _postfixParenthesisString = "";
                    return;
                }
                var peekedOperator = _operatorsStackForParenthesis.Peek();

                if (peekedOperator.Value >= expressionOperator.Value)
                {
                    PopUpTokensToPostfixString(expressionOperator, _operatorsStackForParenthesis, ref _postfixParenthesisString);
                }
                else
                {
                    _operatorsStackForParenthesis.Push(expressionOperator);
                }
                return;
            }
            if (expressionOperator.Token == '(' || expressionOperator.Token == ')')
            {
                _operatorsStackForParenthesis.Push(expressionOperator);
                return;
            }
            if (_operatorsStack.Count > 0)
            {
                var peekedOperator = _operatorsStack.Peek();
                if (peekedOperator.Value >= expressionOperator.Value)
                {
                    PopUpTokensToPostfixString(expressionOperator, _operatorsStack, ref _postfixString);
                }
                else
                {
                    _operatorsStack.Push(expressionOperator);
                }
                return;
            }
            _operatorsStack.Push(expressionOperator);
        }

        private void PushParenthesisTokensFromStack()
        {
            while (_operatorsStackForParenthesis.Count > 0)
            {
                _postfixParenthesisString += _operatorsStackForParenthesis.ElementAt(0).Token;
                _operatorsStackForParenthesis.Pop();
            }
        }

        private void PopUpTokensToPostfixString(Operators expressionOperator, Stack<Operators> inputStack, ref string inputPostfixString)
        {
            var tokenPushToStack = CheckIfFirstDigitShouldBeNegative(expressionOperator, inputStack);
            while (inputStack.Count > 0)
            {
                var peekedOperator = inputStack.Peek();

                if (peekedOperator.Value == expressionOperator.Value && peekedOperator.Token == expressionOperator.Token)
                {
                    inputPostfixString += expressionOperator.Token;
                    tokenPushToStack = false;
                    break;
                }
                if (inputStack.Count == 1 && peekedOperator.Value < expressionOperator.Value)
                {
                    break;
                }
                inputPostfixString += peekedOperator.Token;
                inputStack.Pop();
            }
            if (tokenPushToStack) inputStack.Push(expressionOperator);
        }

        private bool CheckIfFirstDigitShouldBeNegative(Operators expressionOperator, Stack<Operators> inputStack)
        {
            if (inputStack.Count != 1 || !inputStack.Contains(_leftParenthesis) ||
                expressionOperator.Token != '-') return true;
            _postfixString += expressionOperator.Token;
            return false;
        }

        private int CheckNumberOfParenthesis()
        {
            return _operatorsStackForParenthesis.Count(operators => operators.Token == '(');
        }

        private string AddOperatorsFromStackToPostfixString(string expressionInput)
        {
            var result = expressionInput;
            foreach (var operators in _operatorsStack)
            {
                if (operators.Token == '(' || operators.Token == ')')
                    continue;
                result += operators.Token;
            }
            return result;
        }
    }
}
