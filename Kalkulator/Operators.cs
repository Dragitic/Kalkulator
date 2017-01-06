using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator
{
    public class Operators
    {
        public readonly OperatorsSpecification Addition;
        public readonly OperatorsSpecification Subtraction;
        public readonly OperatorsSpecification Multiplication;
        public readonly OperatorsSpecification Division;
        public readonly OperatorsSpecification LeftParenthesis;
        public readonly OperatorsSpecification RightParenthesis;
        public readonly OperatorsSpecification Exponentiation;
        public readonly OperatorsSpecification NullObject;

        public Operators()
        {
            Addition = new OperatorsSpecification() { Token = '+', Value = 1 };
            Subtraction = new OperatorsSpecification() { Token = '-', Value = 1 };
            Multiplication = new OperatorsSpecification() { Token = '*', Value = 2 };
            Division = new OperatorsSpecification() { Token = '/', Value = 2 };
            Exponentiation = new OperatorsSpecification() { Token = '^', Value = 3 };
            LeftParenthesis = new OperatorsSpecification() { Token = '(', Value = 9 };
            RightParenthesis = new OperatorsSpecification() { Token = ')', Value = 9 };
            NullObject = new OperatorsSpecification() { Token = '\'', Value = 0 };
        }
    }
}
