using CalculatorLogic.Logic;
using NUnit.Framework;

namespace CalculatorTest.Logic
{
    [TestFixture]
    public class TestPostfixParser
    {
        private PostfixParser _postfixParser;

        [SetUp]
        public void Init()
        {
            _postfixParser = new PostfixParser();
        }
        [Test]
        public void _01_AddTwoDigits()
        {
            //given
            const string input = "a+b";
            const string expected = "a#b#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _02_MultipleAndAddThreeDigits()
        {
            //given
            const string input = "a*b+c";
            const string expected = "a#b#*c#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _03_MultipleAndAddThreeDigits()
        {
            //given
            const string input = "a+b*c";
            const string expected = "a#b#c#*+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _04_AddThreeDigits()
        {
            //given
            const string input = "a+b+c";
            const string expected = "a#b#+c#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _05_AddFourDigits()
        {
            //given
            const string input = "a+b+c+d";
            const string expected = "a#b#+c#+d#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _06_MultipleAndAddFiveDigits()
        {
            //given
            const string input = "1*2+3*4+5";
            const string expected = "1#2#*3#4#*+5#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _07_MultipleAddAndSubstractSevenDigits()
        {
            //given
            const string input = "2-1+4*5-6+7";
            const string expected = "2#1#-4#5#*+6#-7#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _08_MultipleAddAndSubstractTenDigits()
        {
            //given
            const string input = "2-1+4*5-6+7*8*9-10";
            const string expected = "2#1#-4#5#*+6#-7#8#*9#*+10#-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _09_MultipleAddAndSubstractFourteenDigits()
        {
            //given
            const string input = "2-1+4*5-6+7*8*9-10+11+12*13-14";
            const string expected = "2#1#-4#5#*+6#-7#8#*9#*+10#-11#+12#13#*+14#-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _10_DivideAndMultipleSevenDigits()
        {
            //given
            const string input = "1/2/3/4/5/6*7";
            const string expected = "1#2#/3#/4#/5#/6#/7#*";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _11_MultipleDivideAddAndSubstractNineDigits()
        {
            //given
            const string input = "1*2/3+4-5*6+7-8/9";
            const string expected = "1#2#*3#/4#+5#6#*-7#+8#9#/-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _12_MultipleDivideAddAndSubstractTwelveDigits()
        {
            //given
            const string input = "1*2/3+4-5*6+7-8/9/10/11*12";
            const string expected = "1#2#*3#/4#+5#6#*-7#+8#9#/10#/11#/12#*-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _12_MultipleDivideAddExponentiationAndSubstractFourteenDigits()
        {
            //given
            const string input = "1*2/3+4-5^6+7-8/9/10/11*12+13^2";
            const string expected = "1#2#*3#/4#+5#6#^-7#+8#9#/10#/11#/12#*-13#2#^+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _14_AddTwoNumbersInParenthesis()
        {
            //given
            const string input = "2+(2+2)";
            const string expected = "2#2#2#++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _15_AddMultipleDivideAndSubstractFiveNumbersInParenthesis()
        {
            //given
            const string input = "(5*2+3/4-6)";
            const string expected = "5#2#*3#4#/+6#-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);  
        }
        [Test]
        public void _16_AddMultipleDivideAndSubstractFiveNumbersInParenthesis()
        {
            //given
            const string input = "5*2+(3/4-6)";
            const string expected = "5#2#*3#4#/6#-+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _17_AddMultipleDivideAndSubstractFiveNumbersInTwoParenthesis()
        {
            //given
            const string input = "(5*2)+(3/4-6)";
            const string expected = "5#2#*3#4#/6#-+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _18_AddMultipleDivideAndSubstractSixNumbersInTwoParenthesis()
        {
            //given
            const string input = "(5*2)+(3/1*(4-6))";
            const string expected = "5#2#*3#1#/4#6#-*+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _19_AddMultipleDivideAndSubstractElevenNumbersInTwoParenthesis()
        {
            //given
            const string input = "(-4)*2+(25*2/2+3*(2*2+2))";
            const string expected = "4#-2#*25#2#*2#/3#2#2#*2#+*++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _20_AddMultipleDivideAndSubstractNumbersInTwoParenthesis()
        {
            //given
            const string input = "(-4)*2+(25*2/2+3*(2*2+2))*2+(32-4+5/2)";
            const string expected = "4#-2#*25#2#*2#/3#2#2#*2#+*+2#*+32#4#-5#2#/++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _22_AddMultipleDivideExponentiationAndSubstractNumbersInTwoParenthesis()
        {
            //given
            const string input = "-4*2+(25*2/2+3*(2*^6/2+2))*2+(32-4+5/2)/21*22/(-3*1+2+(-3*2+(2^5)))*2^3";
            const string expected = "4#2#*-25#2#*2#/3#2#6#^*2#/2#+*+2#*+32#4#-5#2#/+21#/22#*3#1#*-2#+3#2#*-2#5#^++/2#3#^*+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _23_AddMultipleDivideExponentiationAndSubstractDoubleNumbersInTwoParenthesis()
        {
            //given
            const string input = "(-4,67)*2+(2,5*2/2+3*(2*^6/2+2))*255,56+(32-4+5/2)/2,1*22/(-3*1+2+(-3*2+(2^5)))*2^3";
            const string expected = "4,67#-2#*2,5#2#*2#/3#2#6#^*2#/2#+*+255,56#*+32#4#-5#2#/+2,1#/22#*3#1#*-2#+3#2#*-2#5#^++/2#3#^*+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _24_AddMultipleDivideExponentiationAndSubstractDoubleNumbersInTwoParenthesis()
        {
            //given
            const string input = "(2^3)+5+(2*3+(40/2))";
            const string expected = "2#3#^5#+2#3#*40#2#/++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _25_AddMultipleDivideExponentiationAndSubstractDoubleNumbersInTwoParenthesis()
        {
            //given
            const string input = "(2^3)+5+(2*3+(40/2))+23,55";
            const string expected = "2#3#^5#+2#3#*40#2#/++23,55#+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
                Assert.AreEqual(expected, result);
        }
        [Test]
        public void _26_AddMultipleDivideExponentiationAndSubstractDoubleNumbersInTwoParenthesis()
        {
            //given
            const string input = "(2^3)+5+(2*3+(40/2))+23,55*(2^4+3-1)/2,2";
            const string expected = "2#3#^5#+2#3#*40#2#/++23,55#2#4#^3#+1#-*2,2#/+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
    }
}