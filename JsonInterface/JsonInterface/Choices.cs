using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Choices : IPattern
    {
        readonly IPattern[] patterns;

        public Choices(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            string textCopy = text;
            foreach (var pattern in patterns)
            {
                var match = pattern.Match(text);
                if (match.Success())
                {
                    return match;
                }
            }

            return new FailedMatch(textCopy);

            // foreach(var pattern in patterns)
#pragma warning disable S125 // Sections of code should not be commented out

                            // {
                            //    if (pattern.Match(text).Success())
                            //        return (IMatch)new SuccessMatch(text.Substring(1));
                            // }
                            // return (IMatch)new FailedMatch(text);
        }
#pragma warning restore S125 // Sections of code should not be commented out
    }
}
