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
            var naturalNumbers = new Choices(zero, allDigits);
            var integerNumbers = new Sequance(new Optionals(minus), naturalNumbers);
            var fractionalPart = new Sequance(
                dot,
                allDigits);
            var exponentialOption = new Any("eE");
            var optionalSign = new Any("+-");
            var exponentialPart = new Sequance(
                exponentialOption,
                optionalSign,
                allDigits);
            pattern = new Sequance(
                integerNumbers,
                new Optionals(fractionalPart),
                new Optionals(exponentialPart));
        }

        public IMatch Match(string text) => pattern.Match(text);
    }
}