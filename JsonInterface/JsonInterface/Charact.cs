using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Charact : IPattern
    {
        readonly char pattern;

        public Charact(char pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || text[0] != pattern
               ? (IMatch)new FailedMatch(text)
               : new SuccessMatch(text.Substring(1));
        }
    }
}
