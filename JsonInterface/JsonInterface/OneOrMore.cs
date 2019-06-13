using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class OneOrMore : IPattern
    {
        readonly IPattern pattern;

        public OneOrMore(IPattern pattern)
        {
            this.pattern = pattern;
        }

        public IMatch Match(string text)
        {
            string textCopy = text;
            var match = pattern.Match(text);
            while (match.Success())
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new SuccessMatch(match.RemainingText());
                }
            }

            return new FailedMatch(textCopy);
        }
    }
}
