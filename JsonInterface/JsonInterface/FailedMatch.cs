using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class FailedMatch : IMatch
    {
        readonly string text;

        public FailedMatch(string text)
        {
            this.text = text;
        }

        public string RemainingText()
        {
            return text;
        }

        public bool Success()
        {
            return false;
        }
    }
}
