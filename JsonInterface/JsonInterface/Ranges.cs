using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Ranges : IPattern
    {
        private readonly char start;
        private readonly char end;

        public Ranges(char start, char end)
        {
            this.start = start;
            this.end = end;
        }

        public IMatch Match(string text)
        {
            return string.IsNullOrEmpty(text) || (start > text[0] || text[0] > end)
                ? (IMatch)new FailedMatch(text)
                : new SuccessMatch(text.Substring(1));
        }
    }
}
