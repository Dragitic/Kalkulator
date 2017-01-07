using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculatorLogic.Logic;
using CalculatorUI.Action;

namespace CalculatorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICalculator _calculator;
        private string _expressionResult = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void digitButton_7_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("7");
        }

        private void digitButton_8_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("8");
        }

        private void digitButton_9_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("9");
        }

        private void digitButton_4_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("4");
        }

        private void digitButton_5_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("5");
        }

        private void digitButton_6_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("6");
        }

        private void digitButton_1_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("1");
        }

        private void digitButton_2_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("2");
        }

        private void digitButton_3_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("3");
        }

        private void digitButton_0_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("0");
        }

        private void comaButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression(",");
        }
        private void leftParetnthesisButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("(");
        }

        private void rightParetnthesisButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression(")");
        }

        private void additionButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("+");
        }

        private void substractionButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("-");
        }

        private void multiplicationButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("*");
        }

        private void divisionButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("/");
        }

        private void exponentationButton_Click(object sender, RoutedEventArgs e)
        {
            AddCharacterToExpression("^");
        }
        private void SumButton_OnClick_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfExpressionIsCorrect())
            {
                _calculator = new Calculator();
                _expressionResult = _calculator.DoCalculation(_expressionResult);
                calculatorTextBox.Text = _expressionResult;
            }
            else
            {
                _expressionResult = "";
                calculatorTextBox.Text = _expressionResult;
            }
        }

        private void AddCharacterToExpression(string input)
        {
            _expressionResult += input;
            calculatorTextBox.Text = _expressionResult;
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            _expressionResult = "";
            calculatorTextBox.Text = _expressionResult;
        }

        private void removeLastCharacterButton_Click(object sender, RoutedEventArgs e)
        {
            if (_expressionResult.Length > 0)
                _expressionResult = _expressionResult.Remove(_expressionResult.Length - 1, 1);
            calculatorTextBox.Text = _expressionResult;
        }

        private void calculatorTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            _expressionResult = calculatorTextBox.Text;
        }

        private bool CheckIfExpressionIsCorrect()
        {
            var leftParenthesisCounter = _expressionResult.Count(expression => expression == '(');
            var rightParenthesisCounter = _expressionResult.Count(expression => expression == ')');

            if (leftParenthesisCounter == rightParenthesisCounter) return true;
            MessageBox.Show("Your expression is invalid. Check if parenthesis are placed correctly");
            return false;
        }
    }
}
