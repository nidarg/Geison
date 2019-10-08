using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class TestClassTesting
    {
        [Theory]
        [InlineData("true", "trueX", "X")]
        [InlineData("true", "true", "")]
        [InlineData("", "true", "true")]

        public void TestClassSuccess(string prefix, string text, string remainingText)
        {
            var e = new Texts(prefix);
            var match = e.Match(text);
            Assert.True(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }

        [Theory]
        [InlineData("true", "truX", "truX")]
        [InlineData("", null, null)]
        [InlineData("true", "", "")]

        public void TestClassFail(string prefix, string text, string remainingText)
        {
            var e = new Texts(prefix);
            var match = e.Match(text);
            Assert.False(match.Success());
            Assert.Equal(remainingText, match.RemainingText());

        }
    }
}
