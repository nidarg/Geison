using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class Numb : IPattern
    {
        private readonly IPattern pattern;

        public Numb()
        {
            var allDigits = new Many(new Ranges('0', '9'));
            var dot = new Charact('.');
            var minus = new Charact('-');
            var zero = new Charact('0');
            var digits = new OneOrMore(new Ranges('1', '9'));
            var naturalNumbers = new OneOrMore(new Sequance(digits, new Optionals(new Many(zero))));

            // var integerNumbers = new Choices(
            //    zero,
#pragma warning disable S125 // Sections of code should not be commented out

                            // new Sequance(new Optionals(minus), naturalNumbers));
                            // var allReals = new Choices(
                            //    new Texts("-0"),
                            //    integerNumbers);
                            // var realNumbers = new Choices(
                            //    new Sequance(
                            //        new Optionals(minus),
                            //        zero,
                            //        dot,
                            //        allDigits),
                            //    zero,
                            //    new Sequance(
                            //        new Optionals(minus),
                            //        naturalNumbers,
                            //        new Optionals(dot),
                            //        new Optionals(allDigits)));
            var exponentialOption = new Any("eE");
#pragma warning restore S125 // Sections of code should not be commented out
            var optionalSign = new Any("+-");

            var exponentialNum = new Choices(
                new Sequance(
                    new Optionals(minus),
                    zero,
                    dot,
                    allDigits,
                    new Optionals(exponentialOption),
                    new Optionals(optionalSign),
                    new Optionals(digits)),
                zero,
                new Sequance(
                    new Optionals(minus),
                    naturalNumbers,
                    new Optionals(dot),
                    new Optionals(allDigits),
                    new Optionals(exponentialOption),
                    new Optionals(optionalSign),
                    new Optionals(digits)));
#pragma warning disable RCS1124FadeOut // Inline local variable.
            pattern = exponentialNum;
#pragma warning restore RCS1124FadeOut // Inline local variable.
        }

        public IMatch Match(string text) => pattern.Match(text);
    }
}
