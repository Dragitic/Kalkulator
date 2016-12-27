using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalkulator.CalculatorOperators
{
    class PlusOperator : IOperators
    {
        public OperatorsDescription OperandsDescription { get; private set; }

        public OperatorsDescription GetOperatorKeyValue()
        {
            return OperandsDescription = new OperatorsDescription() { OperatorKey = '+', OperatorValue = 1 };
        }
    }
}
