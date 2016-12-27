using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kalkulator.Calculator.Operators;
using Kalkulator.CalculatorOperators;

namespace Kalkulator
{
    public class OperatorFactory
    {
        readonly IOperators _iOperators;
        private char _key;
        private int _value;

        public OperatorFactory(char input)
        {
            switch (input)
            {
                case '+':
                    _iOperators = new PlusOperator();
                    GetOperatorProperties();
                    break;
                case '-':
                    _iOperators = new MinusOperator();
                    GetOperatorProperties();
                    break;
                case '*':
                    _iOperators = new MultiplicationOperator();
                    GetOperatorProperties();
                    break;
            }
        }

        private void GetOperatorProperties()
        {
            _key = _iOperators.GetOperatorKeyValue().OperatorKey;
            _value = _iOperators.GetOperatorKeyValue().OperatorValue;
        }

        public char GetOperatorKey()
        {
            return _key;
        }

        public int GetOperatorValue()
        {
            return _value;
        }
    }
}
