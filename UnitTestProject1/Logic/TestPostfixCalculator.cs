using Kalkulator.Logic;
using NUnit.Framework;

namespace CalculatorTest.Logic
{
    [TestFixture]
    public class TestPostfixCalculator
    {
        private PostfixCalculator _postfixCalculator;
        
        [SetUp]
        public void Init()
        {
            _postfixCalculator = new PostfixCalculator();
        }
        [Test]
        public void _01_AddTwoDigits()
        {
            //given
            const string input = "2#2#+";
            const string expected = "4";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _02_AddTreeDigits()
        {
            //given
            const string input = "2#2#+#3#+";
            const string expected = "7";

            //when
                var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _03_AddFourDigits()
        {
            //given
            const string input = "2#2#+#3#+#5#+";
            const string expected = "12";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _04_AddAndSubstractDigits()
        {
            //given
            const string input = "2#2#+#3#+#5#+#7#-";
            const string expected = "5";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _05_AddAndSubstractDigits()
        {
            //given
            const string input = "2#1#+#5#+#3#-#1#-#2#+#3#-";
            const string expected = "3";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _06_MultipleAndAddDigits()
        {
            //given
            const string input = "1#2#*#3#4#*#+#5#+";
            const string expected = "19";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _07_MultipleAndAddDigits()
        {
            //given
            const string input = "2#1#-#4#5#*#+#6#-#7#+";
            const string expected = "22";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _08_MultipleAndAddDigits()
        {
            //given
            const string input = "2#1#-#4#5#*#+#6#-#7#8#*#9#*#+#1#-";
            const string expected = "518";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _09_MultipleAndAddDigits()
        {
            //given
            const string input = "2#1#-#4#5#*#+#6#-#7#8#*#9#*#+#10#-";
            const string expected = "509";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _09_MultipleDivideAndAddDigits()
        {
            //given
            const string input = "2#1#-#4#5#*#+#6#-#7#8#*#9#*#+#10#11#/#-#12#13#*#1#/#+";
            const string expected = "674.091";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _10_MultipleDivideAndAddInParenthesisDigits()
        {
            //given
            const string input = "5#2#*#3#4#/#6#-#+";
            const string expected = "4.75";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _11_MultipleDivideAndAddInParenthesisDigits()
        {
            //given
            const string input = "5#2#*#3#1#/#4#6#-#*#+";
            const string expected = "4";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _12_MultipleDivideAndAddInParenthesisDigits()
        {
            //given
            const string input = "4#-2#*25#2#*2#/3#2#2#*2#+*++";
            const string expected = "35";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _13_MultipleDivideAndAddInParenthesisDigits()
        {
            //given
            const string input = "4#-2#*25#2#*2#/3#2#2#*2#+*+2#*+32#4#-5#2#/++";
            const string expected = "108.5";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _14_MultipleDivideExponentiationAndAddInParenthesisDigits()
        {
            //given
            const string input = "2#3#^5#+2#3#*40#2#/++";
            const string expected = "39";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _15_MultipleDivideExponentiationAndAddInParenthesisDigits()
        {
            //given
            const string input = "2#3#^5#+2#3#*40#2#/++23,55#+";
            const string expected = "62.55";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _16_MultipleDivideExponentiationAndAddInParenthesisDigits()
        {
            //given
            const string input = "2#3#^5#+2#3#*40#2#/++23,55#2#4#^3#+1#-*2,2#/+";
            const string expected = "231.682";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
    }
}
