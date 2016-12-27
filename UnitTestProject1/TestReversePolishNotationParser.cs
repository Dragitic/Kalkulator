using System;
using Kalkulator.Calculator.Parser;
using NUnit.Framework;

namespace UnitTestProject1
{
    //[TestFixture]
    //public class TestReversePolishNotationParser
    //{
    //    private string _input;
    //    private string _expeted;
    //    private ReversePolishNotationParser _reversePolishNotationParser;

    //    [Test]
    //    public void ShouldReciveCorrectNotationOfTwoAddedDigits()
    //    {
    //        //given
    //        _input = "2+3";
    //        _expeted = "23+";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }

    //    [Test]
    //    public void ShouldReciveCorrectNotationOfThreeAddedDigits()
    //    {
    //        //given
    //        _input = "2+3+4";
    //        _expeted = "23+4+";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }

    //    [Test]
    //    public void ShouldReciveCorrectNotationOfFourAddedDigits()
    //    {
    //        //given
    //        _input = "2+3+4+6";
    //        _expeted = "23+4+6+";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }

    //    [Test]
    //    public void ShouldReciveCorrectNotationOfFourAddedDigitsWithDifferentOperators()
    //    {
    //        //given
    //        _input = "2+3+4-6";
    //        _expeted = "23+4+6-";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }

    //    [Test]
    //    public void ShouldReciveCorrectNotationOfFiveAddedDigitsWithDifferentOperators()
    //    {
    //        //given
    //        _input = "2+3+4-6*23";
    //        _expeted = "23+4+623*-";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }
    //    [Test]
    //    public void ShouldReciveCorrectNotationOfSixAddedDigitsWithDifferentOperators()
    //    {
    //        //given
    //        _input = "2*3+4-6*23*55";
    //        _expeted = "23*4+623*55*-";
    //        _reversePolishNotationParser = new ReversePolishNotationParser();

    //        //when
    //        var result = _reversePolishNotationParser.ParseInput(_input);

    //        //then
    //        Assert.AreEqual(_expeted, result);
    //    }
    //}
}
