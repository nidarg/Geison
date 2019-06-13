using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Sequance : IPattern
    {
        readonly IPattern[] patterns;

        public Sequance(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            IMatch match = new SuccessMatch(text);
            foreach (var pattern in patterns)
            {
                match = pattern.Match(match.RemainingText());
                if (!match.Success())
                {
                    return new FailedMatch(text);
                }
            }

            return match;

#pragma warning disable S125 // Sections of code should not be commented out

                            // string textCopy = text;

            // foreach (var pattern in patterns)
            // {
            //    var match = pattern.Match(text);
            //    if (match.Success())
            //    {

            // text = match.RemainingText();
            //    }
            //    else return new FailedMatch(textCopy);

            // }
            // return new SuccessMatch(text);
        }
#pragma warning restore S125 // Sections of code should not be commented out
    }
}
