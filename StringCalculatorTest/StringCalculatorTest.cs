using NSubstitute;
using NUnit.Framework;
using String_Calculator_2;
using String_Calculator_2.Interfaces;
using System.Collections.Generic;

namespace StringCalculator2Test
{
    public class StringCalculatorTest
    {
        private StringCalculator _stringCalculator;
        private ICalculations _calculationsMock;
        private INumbers _numbersMock;
        private ISplit _splitMock;
        private IDelimiters _delimitersMock;

        [SetUp]
        public void Setup()
        {
            _calculationsMock = Substitute.For<ICalculations>();
            _numbersMock = Substitute.For<INumbers>();
            _splitMock = Substitute.For<ISplit>();
            _delimitersMock = Substitute.For<IDelimiters>();
            _stringCalculator = new StringCalculator(_calculationsMock, _numbersMock, _delimitersMock, _splitMock);
        }

        [Test]
        public void WhenEmptyString_UsingSubtraction_ResultsReturnsZero()
        {
            // arrange
            const int expected = 0;
            const string input = "";

            // act 
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithOneNumber_UsingSubtract_ResultsReturnsDifference()
        {
            // arrange
            const string input = "1";
            const int expected = -1;
            var delimitersList = new List<string> { ",", "\n" };
            string[] numbersStringArray = { "1" };
            var numbersList = new List<int>() { 1 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitMock.GetNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumberToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenArrayOfIntegers_UsingSubtract_ResultsReturnsDifference()
        {
            // arrange
            const string input = "1,2";
            const int expected = -3;
            var delimitersList = new List<string> { ",", "\n" };
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitMock.GetNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumberToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithANewDelimiter_UsingSubtract_ResultsReturnsSum()
        {
            // arrange
            const string input = "##;\n1;2";
            const int expected = -3;
            var delimitersList = new List<string> { ",", "\n", ";" };
            string[] numbersStringArray = { "1", "2" };
            var numbersList = new List<int>() { 1, 2 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitMock.GetNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumberToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenUsingSquareBracketAsADelimiter_UsingSubtract_ResultsReturnsSum()
        {
            // arrange
            const string input = "##[\n1[2[10";
            const int expected = -13;
            var delimitersList = new List<string> { ",", "\n", "[" };
            string[] numbersStringArray = { "1", "2", "10" };
            var numbersList = new List<int>() { 1, 2, 10 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitMock.GetNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumberToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenUsingStringWithFlaggedDelimiters_UsingSubtract_ResultsReturnsSum()
        {
            // arrange
            const string input = "<(>)##(*)\n1*2*3";
            const int expected = -6;
            var delimitersList = new List<string> { ",", "\n", "*" };
            string[] numbersStringArray = { "1", "2", "3" };
            var numbersList = new List<int>() { 1, 2, 3 };

            // act 
            _delimitersMock.GetDelimiters(input).Returns(delimitersList);
            _splitMock.GetNumbers(input, delimitersList).Returns(numbersStringArray);
            _numbersMock.ConvertStringNumberToInt(numbersStringArray).Returns(numbersList);
            _calculationsMock.PerformCalculation(numbersList).Returns(expected);
            var results = _stringCalculator.Subtract(input);

            // assert
            Assert.AreEqual(expected, results);
        }
    }
}