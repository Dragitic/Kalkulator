using System.Collections.Generic;
using System.Linq;
using Calculator;

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
        private readonly Operators _exponentiation;
        private readonly Operators _nullObject;

        private Stack<Operators> _operatorsStack;
        private List<Stack<Operators>> _listOfParenthesisStack;

        private string _postfixString;
        private string _postfixParenthesisString;
        private string _postfixFinalString;

        private int _leftParenthesisCounter = -1;
        public PostfixParser()
        {
            _addition = new Operators() { Token = '+', Value = 1 };
            _subtraction = new Operators() { Token = '-', Value = 1 };
            _multiplication = new Operators() { Token = '*', Value = 2 };
            _division = new Operators() { Token = '/', Value = 2 };
            _exponentiation = new Operators() { Token = '^', Value = 3 };
            _leftParenthesis = new Operators() { Token = '(', Value = 9 };
            _rightParenthesis = new Operators() { Token = ')', Value = 9 };
            _nullObject = new Operators() { Token = '\'', Value = 0 };
        }
        public string TryParse(string expression)
        {
            var mainExpression = expression;
            _operatorsStack = new Stack<Operators>();
            _listOfParenthesisStack = new List<Stack<Operators>>();

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
                    case '^':
                        CheckPrecendese(_exponentiation);
                        break;
                    case '(':
                        _leftParenthesisCounter++;
                        _listOfParenthesisStack.Add(new Stack<Operators>());
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
        private void CheckPrecendese(Operators expressionOperator)
        {
            var parenthesisOperatorStack = GetOperatorsStackFromParenthesisList();
            Operators peekedOperator;

            if (parenthesisOperatorStack.Count > 0)
            {
                if (expressionOperator.Token == ')')
                {
                    PushParenthesisTokensFromStack();
                    _postfixString += _postfixParenthesisString;
                    _postfixParenthesisString = "";
                    return;
                }
                peekedOperator = parenthesisOperatorStack.Count > 0 ? parenthesisOperatorStack.Peek() : _nullObject;

                if (peekedOperator.Value >= expressionOperator.Value)
                {
                    PopUpTokensToPostfixString(expressionOperator, parenthesisOperatorStack, ref _postfixParenthesisString);
                }
                else
                {
                    parenthesisOperatorStack.Push(expressionOperator);
                }
                return;
            }
            if (expressionOperator.Token == '(' || expressionOperator.Token == ')')
            {
                parenthesisOperatorStack.Push(expressionOperator);
                return;
            }
            if (_operatorsStack.Count > 0)
            {
                peekedOperator = _operatorsStack.Peek();
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
        private Stack<Operators> GetOperatorsStackFromParenthesisList()
        {
            return _listOfParenthesisStack.Count > 0 ? _listOfParenthesisStack.ElementAt(_leftParenthesisCounter) : new Stack<Operators>();
        }
        private void WriteNonOperatorToPostfixString(char t)
        {
            if (_listOfParenthesisStack.Count > 0)
            {
                _postfixParenthesisString += t;
            }
            else
            {
                _postfixString += t;
            }
        }
        private void PushParenthesisTokensFromStack()
        {
            _listOfParenthesisStack.Reverse();
            foreach (var parenthesisStack in _listOfParenthesisStack)
            {
                while (parenthesisStack.Count > 0)
                {
                    _postfixParenthesisString += parenthesisStack.ElementAt(0).Token;
                    parenthesisStack.Pop();
                }
            }
            _listOfParenthesisStack.Clear();
            _leftParenthesisCounter = -1;
        }
        private static void PopUpTokensToPostfixString(Operators expressionOperator, Stack<Operators> inputStack, ref string inputPostfixString)
        {
            var tokenPushToStack = true;
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
        private string AddOperatorsFromStackToPostfixString(string expressionInput)
        {
            return _operatorsStack.Where(operators => operators.Token != '(' && operators.Token != ')').Aggregate(expressionInput, (current, operators) => current + operators.Token);
        }
    }
}
