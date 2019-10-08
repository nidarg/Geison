using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Texts : IPattern
    {
        readonly string prefix;

        public Texts(string prefix)
        {
            this.prefix = prefix;
        }

        public IMatch Match(string text)
        {
            if ((prefix == "") && (text != null))
            {
                return new SuccessMatch(text);
            }

            if (string.IsNullOrEmpty(text) || !text.Contains(prefix))
            {
                return new FailedMatch(text);
            }

            return new SuccessMatch(text.Substring(prefix.Length));
        }
    }
}
