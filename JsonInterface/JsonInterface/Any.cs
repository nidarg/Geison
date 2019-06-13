using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Any : IPattern
    {
        readonly string accepted;

        public Any(string accepted)
        {
            this.accepted = accepted;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text) || accepted.IndexOf(text[0].ToString(), StringComparison.CurrentCultureIgnoreCase) < 0)
            {
                return new FailedMatch(text);
            }

            return new SuccessMatch(text.Substring(1));
        }
    }
}
