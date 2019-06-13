using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace JsonInterface
{
    public class MyList : IPattern
    {
        readonly IPattern element;
        readonly IPattern separator;

        public MyList(IPattern element, IPattern separator)
        {
            this.element = element;
            this.separator = separator;
        }

        public IMatch Match(string text)
        {
            Many pattern = new Many(new Sequance(separator, element));
            if (string.IsNullOrEmpty(text))
            {
                return new SuccessMatch(text);
            }

            if (element.Match(text).Success())
            {
                return pattern.Match(text: text.Substring(1));
            }

            return new SuccessMatch(text);

#pragma warning disable S125 // Sections of code should not be commented out
#pragma warning disable SA1515 // Single-line comment should be preceded by blank line
                              // Sequance mySequance = new Sequance(element, separator,element);
                              // Sequance yourSequance = new Sequance(separator, element);

            // Many sequance1 = new Many(mySequance);
            // Many sequance2 = new Many(yourSequance);
            // var a = sequance1.Match(text);
            // var b = sequance2.Match(a.RemainingText());

            // if (string.IsNullOrEmpty(text)) return new SuccessMatch(a.RemainingText());
            // else if (element.Match(b.RemainingText()).Success()) return new SuccessMatch(element.Match(b.RemainingText()).RemainingText());
            // else
            // {

            // return new SuccessMatch( b.RemainingText() );
            // }

            // var elem = new OneOrMore(element);
            // var sep = new OneOrMore(separator);

            // var matchElem = elem.Match(text);
            // var matchSep = sep.Match(matchElem.RemainingText());
            // while (matchElem.Success())
            // {

            // var previous = matchElem;
            //    text = matchSep.RemainingText();
            //    matchElem = elem.Match(text);
            //    matchSep = sep.Match(matchElem.RemainingText());
            //    if (!matchElem.Success()) return new SuccessMatch(previous.RemainingText());

            // }
            // return new SuccessMatch(matchElem.RemainingText());

            // string textCopy = text;
            // var elem = element.Match(text);
            // var sep = separator.Match(elem.RemainingText());

            // while (elem.Success())
            // {
            //    if (!sep.Success()) return new SuccessMatch(elem.RemainingText());
            //    var previous = elem;
            //    elem = element.Match(sep.RemainingText());
            //    if (!elem.Success()) return new SuccessMatch(previous.RemainingText());
            //    sep = separator.Match(elem.RemainingText());

            ////  return new SuccessMatch(sep.RemainingText());
            // }
            // return new SuccessMatch(textCopy);
        }
#pragma warning restore SA1515 // Single-line comment should be preceded by blank line
#pragma warning restore S125 // Sections of code should not be commented out
    }
}
