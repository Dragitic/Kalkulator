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

        private string _postfixString;
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

            ExpressionActionCreator(mainExpression);
            _postfixFinalString = AddOperatorsFromStackToPostfixString(_postfixString);

            return RemoveParenthesisFromExpression(_postfixFinalString);
        }

        private string RemoveParenthesisFromExpression(string expression)
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
                        _leftParenthesis.Value++;  //todo
                        CheckPrecendese(_leftParenthesis);
                        break;
                    case ')':
                        _rightParenthesis.Value++; //todo
                        CheckPrecendese(_rightParenthesis);
                        break;
                    default:
                        _postfixString += t;
                        break;
                }
            }
        }

        private void CheckPrecendese(Operators expressionOperator)
        {
            if (_operatorsStack.Count > 0)
            {
                var peekedOperator = _operatorsStack.Peek();
                if (peekedOperator.Value >= expressionOperator.Value)
                {
                    PopUpTokensToPostfixString(expressionOperator);
                }
                else
                {
                    _operatorsStack.Push(expressionOperator);
                }
                return;
            }
            _operatorsStack.Push(expressionOperator);
        }
        private void PopUpTokensToPostfixString(Operators expressionOperator)
        {
            var tokenPushToStack = true;
            while (_operatorsStack.Count > 0)
            {
                var peekedOperator = _operatorsStack.Peek();
                if (peekedOperator.Token == '(')
                {
                    break;
                }
                if (peekedOperator.Value == expressionOperator.Value && peekedOperator.Token == expressionOperator.Token)
                {
                    _postfixString += expressionOperator.Token;
                    tokenPushToStack = false;
                    break;
                }
                if (_operatorsStack.Count == 1 && peekedOperator.Value < expressionOperator.Value)
                {
                    break;
                }
                _postfixString += peekedOperator.Token;
                _operatorsStack.Pop();
            }
            if (tokenPushToStack) _operatorsStack.Push(expressionOperator);
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
