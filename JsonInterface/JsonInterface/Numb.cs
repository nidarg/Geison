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
            var digits = new OneOrMore(new Ranges('1', '9'));
            var positiveNum = new Sequance(
               digits,
               allDigits);
            var negativeNum = new Sequance(
                new Charact('-'),
                positiveNum);
            var realNum = new Sequance(
                new Optionals(new Charact('-')),
                new OneOrMore(new Ranges('0', '9')),
                dot,
                new OneOrMore(new Ranges('0', '9')));
            var exponentialOption = new Choices(
                new Charact('e'),
                new Charact('E'));
            var optionalSign = new Choices(
                new Charact('+'),
                new Charact('-'));
            var exponentialNum = new Sequance(
                realNum,
                exponentialOption,
                optionalSign,
                digits);
            pattern = new Choices(
                exponentialNum,
                realNum,
                negativeNum,
                positiveNum);
        }

        public IMatch Match(string text) => pattern.Match(text);
    }
}