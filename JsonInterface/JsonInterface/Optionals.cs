using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Optionals : IPattern
    {
        readonly IPattern pattern;

        public Optionals(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            var match = pattern.Match(text);

            return !match.Success() ? new SuccessMatch(text) : match;
        }
    }
}
