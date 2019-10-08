using JsonInterface;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace JsonInterfaceTest
{
    public class MyStringClassTest
    {
        [Theory]
        [InlineData("fh jf\t gjg0\n", "")]
        public void TestStringWithEscapeCharacters(string text, string remainingText)
        {
            IMatch matchString = new MyString().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchString.RemainingText());
        }

        [Theory]
        [InlineData("dtfthfg", "")]
        public void TestStringOnlyCharacters(string text, string remainingText)
        {
            IMatch matchString = new MyString().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchString.RemainingText());
        }

        [Theory]
        [InlineData("abc \u0023 ac\n", "")]
        public void TestStringUnicode(string text, string remainingText)
        {
            IMatch matchString = new MyString().Match(text);
            //Assert.True(matchNumber.Success());
            Assert.Equal(remainingText, matchString.RemainingText());
        }


    }
}
