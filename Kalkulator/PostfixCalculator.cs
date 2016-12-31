using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    public class PostfixCalculator
    {
        private Stack<double> _numbersStack;

        public PostfixCalculator()
        {
            _numbersStack = new Stack<double>();
        }
        public string Calculate(string input)
        {
            foreach (var character in input)
            {
                
            }
            return "";
        }
    }
}
