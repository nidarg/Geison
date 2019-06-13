using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Many : IPattern
    {
         readonly IPattern pattern;

         public Many(IPattern pattern)
        {
            this.pattern = pattern;
        }

         public IMatch Match(string text)
        {
            string textCopy = text;
            var match = pattern.Match(text);
            while (match.Success())
            {
                var previous = match;
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new SuccessMatch(match.RemainingText());
                }
            }

            return new SuccessMatch(textCopy);
        }
    }
}
