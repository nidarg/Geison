using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace JsonInterfaceTest
{
    public class OptionalClassTest
    {
        [Theory]
        [InlineData("abc", "bc")]
        [InlineData("aaaabcd", "aaabcd")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("bcdef", "bcdef")]


        public void TestOptionalCharSuccess(string text, string remainingText)
        {
            var optionalChar = new Optionals(new Charact('a'));

            var matchChar = optionalChar.Match(text);

            Assert.True(matchChar.Success());
            Assert.Equal(remainingText, matchChar.RemainingText());

        }

        [Theory]
        [InlineData("12345ab123", "2345ab123")]
        [InlineData("bcd", "bcd")]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("bcdef", "bcdef")]


        public void TestOptionalRangeSuccess(string text, string remainingText)
        {

            var optionalRange = new Optionals(new Ranges('0', '9'));

            var matchRange = optionalRange.Match(text);
            Assert.True(matchRange.Success());
            Assert.Equal(remainingText, matchRange.RemainingText());

        }

    }
}
