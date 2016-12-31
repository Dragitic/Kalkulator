using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculator;
using NUnit.Framework;

namespace UnitTestProject1
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
            const string input = "22+";
            const string expected = "4";

            //when
            var result = _postfixCalculator.Calculate(input);

            //then
            Assert.AreEqual(expected, result);
        }
    }
}
