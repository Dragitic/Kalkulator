using System.Collections.Generic;
using System.Linq;
using Calculator;

namespace Kalkulator
{
    public class PostfixParser
    {
        private readonly Operators _postfixOperator;

        private Stack<OperatorsSpecification> _operatorsStack;
        private List<Stack<OperatorsSpecification>> _listOfParenthesisStack;

        private string _postfixString;
        private string _postfixParenthesisString;
        private string _postfixFinalString;

        private int _leftParenthesisCounter = -1;
        public PostfixParser()
        {
            _postfixOperator = new Operators();
        }
        public string TryParse(string expression)
        {
            var mainExpression = expression;
            _operatorsStack = new Stack<OperatorsSpecification>();
            _listOfParenthesisStack = new List<Stack<OperatorsSpecification>>();

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
            for (var i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '^':
                        CheckPrecendese(_postfixOperator.Exponentiation);
                        break;
                    case '*':
                        CheckPrecendese(_postfixOperator.Multiplication);
                        break;
                    case '/':
                        CheckPrecendese(_postfixOperator.Division);
                        break;
                    case '+':
                        CheckPrecendese(_postfixOperator.Addition);
                        break;
                    case '-':
                        CheckPrecendese(_postfixOperator.Subtraction);
                        break;
                    case '(':
                        _leftParenthesisCounter++;
                        _listOfParenthesisStack.Add(new Stack<OperatorsSpecification>());
                        CheckPrecendese(_postfixOperator.LeftParenthesis);
                        break;
                    case ')':
                        CheckPrecendese(_postfixOperator.RightParenthesis);
                        break;
                    default:
                        WriteNumberToPostfixString(expression, i);
                        break;
                }
            }
        }
        private void CheckPrecendese(OperatorsSpecification expressionOperatorSpecification)
        {
            var parenthesisOperatorStack = GetOperatorsStackFromParenthesisList();
            OperatorsSpecification peekedOperatorSpecification;

            if (parenthesisOperatorStack.Count > 0)
            {
                if (expressionOperatorSpecification.Token == ')')
                {
                    PushParenthesisTokensFromStack();
                    _postfixString += _postfixParenthesisString;
                    _postfixParenthesisString = "";
                    return;
                }
                peekedOperatorSpecification = parenthesisOperatorStack.Count > 0 ? parenthesisOperatorStack.Peek() : _postfixOperator.NullObject;

                if (peekedOperatorSpecification.Value >= expressionOperatorSpecification.Value)
                {
                    PopUpTokensToPostfixString(expressionOperatorSpecification, parenthesisOperatorStack, ref _postfixParenthesisString);
                }
                else
                {
                    parenthesisOperatorStack.Push(expressionOperatorSpecification);
                }
                return;
            }
            if (expressionOperatorSpecification.Token == '(' || expressionOperatorSpecification.Token == ')')
            {
                parenthesisOperatorStack.Push(expressionOperatorSpecification);
                return;
            }
            if (_operatorsStack.Count > 0)
            {
                peekedOperatorSpecification = _operatorsStack.Peek();
                if (peekedOperatorSpecification.Value >= expressionOperatorSpecification.Value)
                {
                    PopUpTokensToPostfixString(expressionOperatorSpecification, _operatorsStack, ref _postfixString);
                }
                else
                {
                    _operatorsStack.Push(expressionOperatorSpecification);
                }
                return;
            }
            _operatorsStack.Push(expressionOperatorSpecification);
        }
        private Stack<OperatorsSpecification> GetOperatorsStackFromParenthesisList()
        {
            return _listOfParenthesisStack.Count > 0 ? _listOfParenthesisStack.ElementAt(_leftParenthesisCounter) : new Stack<OperatorsSpecification>();
        }
        private void WriteNumberToPostfixString(string expression, int position)
        {
            var result = ValidateIfExpressionIsStillANumber(expression, position);

            if (_listOfParenthesisStack.Count > 0)
            {
                _postfixParenthesisString += expression[position];
                if (!result)
                    _postfixParenthesisString += "#";
            }
            else
            {
                _postfixString += expression[position];
                if (!result)
                    _postfixString += "#";
            }
        }
        private static bool ValidateIfExpressionIsStillANumber(string expression, int position)
        {
            int countedPosition;
            if (expression.Length - 1 == position)
                countedPosition = position;
            else
                countedPosition = position + 1;

            double pushHashtagToPostfix;
            var result = expression[countedPosition] == ',' || double.TryParse(expression[countedPosition].ToString(), out pushHashtagToPostfix);
            return result;
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
        private static void PopUpTokensToPostfixString(OperatorsSpecification expressionOperatorSpecification, Stack<OperatorsSpecification> inputStack, ref string inputPostfixString)
        {
            var tokenPushToStack = true;
            while (inputStack.Count > 0)
            {
                var peekedOperator = inputStack.Peek();

                if (peekedOperator.Value == expressionOperatorSpecification.Value && peekedOperator.Token == expressionOperatorSpecification.Token)
                {
                    inputPostfixString += expressionOperatorSpecification.Token;
                    tokenPushToStack = false;
                    break;
                }
                if (inputStack.Count == 1 && peekedOperator.Value < expressionOperatorSpecification.Value)
                {
                    break;
                }
                inputPostfixString += peekedOperator.Token;
                inputStack.Pop();
            }
            if (tokenPushToStack) inputStack.Push(expressionOperatorSpecification);
        }
        private string AddOperatorsFromStackToPostfixString(string expressionInput)
        {
            if (CheckIfLastNumberHasHashtag(expressionInput))
                expressionInput += "#";

            return _operatorsStack.Where(operators => operators.Token != '(' && operators.Token != ')').Aggregate(expressionInput, (current, operators) => current + operators.Token);
        }
        private static bool CheckIfLastNumberHasHashtag(string expressionInput)
        {
            var expression = expressionInput.Reverse();
            var character = expression.ElementAt(0);
            double number;
            var result = double.TryParse(character.ToString(), out number);
            return result;
        }
    }
}
