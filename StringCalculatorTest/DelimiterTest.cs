using NUnit.Framework;
using String_Calculator_2.Services;
using System.Collections.Generic;

namespace StringCalculatorTest.Classes_Test_Cases
{
    public class DelimiterTest
    {
        private DelimiterService _delimiters;

        [SetUp]
        public void Setup()
        {
            _delimiters = new DelimiterService();
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingDelimeter_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "##[*][%][:][;]\n";
            var expected = new List<string> { ",", "\n", "*", "%", ":", ";" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingGetMultipleDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "[*][%][:][;]";
            string[] expected = { "*", "%", ":", ";" };

            // act 
            var results = _delimiters.GetMultipleDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringWithMultipleDelimiter_UsingFlagDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "<(>)";
            //const string delimiters = "<>><##>*<>%<\n1";
            const string delimiters = "<(>)##(%)\n1";
            string[] expected = { "%" };

            // act 
            var results = _delimiters.FlagDelimiters(delimiters, input);

            // assert
            Assert.AreEqual(expected, results);
        }
        [Test]
        public void WhenStringFlagDelimiter_UsingFlagDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "<>><##>*<>%<\n1";
            string[] expected = { ",", "\n", "*", "%" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringFlagDelimiters_UsingFlagDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "<>><##>$$$<>%<\n1";
            string[] expected = { ",", "\n", "$$$", "%" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }

        [Test]
        public void WhenStringMultipleFlaggedDelimiters_UsingFlagDelimeters_ResultsReturnsArrayOfDelimiters()
        {
            // arrange
            const string input = "<>><##>$$$<>###<\n";
            string[] expected = { ",", "\n", "$$$", "###" };

            // act 
            var results = _delimiters.GetDelimiters(input);

            // assert
            Assert.AreEqual(expected, results);
        }
    }
}
