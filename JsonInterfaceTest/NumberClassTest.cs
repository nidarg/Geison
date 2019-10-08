using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class NumberClassTest
    {
        [Theory]
        [InlineData("455020", "")]
        public void TestPositiveNumberSuccess(string text, string remainingText)
        {
            IMatch matchNumber = new Numb().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchNumber.RemainingText());
        }

        [Theory]
        [InlineData("-455020", "")]
        public void TestNegativeNumberSuccess(string text, string remainingText)
        {
            IMatch matchNumber = new Numb().Match(text);
            // Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchNumber.RemainingText());
        }
        [Theory]
        [InlineData("-1.0203", "")]
        [InlineData("354.232", "")]
        [InlineData("0.0678", "")]
        public void TestPositiveNegativeRealNumberSuccess(string text, string remainingText)
        {
            IMatch matchNumber = new Numb().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchNumber.RemainingText());
        }

        [Theory]
        [InlineData("-1.0203e+2", "")]
        [InlineData("354.232E-3", "")]
        [InlineData("0.0678e-2", "")]
        public void TestExponentialNumberSuccess(string text, string remainingText)
        {
            IMatch matchNumber = new Numb().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchNumber.RemainingText());
        }
    }
}
