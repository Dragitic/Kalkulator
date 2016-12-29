using System;
using Kalkulator;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    public class TestPostFixParser
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
            const string expected = "ab+";

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
            const string expected = "ab*c+";

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
            const string expected = "abc*+";

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
            const string expected = "ab+c+";

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
            const string expected = "ab+c+d+";

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
            const string expected = "12*34*+5+";

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
            const string expected = "21-45*+6-7+";

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
            const string expected = "21-45*+6-78*9*+10-";

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
            const string expected = "21-45*+6-78*9*+10-11+1213*+14-";

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
            const string expected = "12/3/4/5/6/7*";

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
            const string expected = "12*3/4+56*-7+89/-";

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
            const string expected = "12*3/4+56*-7+89/10/11/12*-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _13_AddTwoNumbersInParenthesis()
        {
            //given
            const string input = "2+(2+2)";
            const string expected = "222++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _14_AddMultipleDivideAndSubstractFiveNumbersInParenthesis()
        {
            //given
            const string input = "(5*2+3/4-6)";
            const string expected = "52*34/+6-";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);  
        }
        [Test]
        public void _15_AddMultipleDivideAndSubstractFiveNumbersInParenthesis()
        {
            //given
            const string input = "5*2+(3/4-6)";
            const string expected = "52*34/6-+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _16_AddMultipleDivideAndSubstractFiveNumbersInTwoParenthesis()
        {
            //given
            const string input = "(5*2)+(3/4-6)";
            const string expected = "52*34/6-+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _17_AddMultipleDivideAndSubstractSixNumbersInTwoParenthesis()
        {
            //given
            const string input = "(5*2)+(3/1*(4-6))";
            const string expected = "52*31/46-*+";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _18_AddMultipleDivideAndSubstractElevenNumbersInTwoParenthesis()
        {
            //given
            const string input = "(-4)*2+(25*2/2+3*(2*2+2))";
            const string expected = "-42*252*2/322*2+*++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void _19_AddMultipleDivideAndSubstractNumbersInTwoParenthesis()
        {
            //given
            const string input = "(-4)*2+(25*2/2+3*(2*2+2))*2+(32-4+5/2)";
            const string expected = "-42*252*2/322*2+*+2*+324-52/++";

            //when
            var result = _postfixParser.TryParse(input);

            //then
            Assert.AreEqual(expected, result);
        }
    }
}