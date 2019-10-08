using System;
using System.Collections.Generic;
using System.Text;

namespace JsonInterface
{
    public class MyString : IPattern
    {
        private readonly IPattern pattern;

        public MyString()
        {
            var forbidenCharacters = new Choices(
                new Optionals(new Charact('\u005C')),
                new Many(new Charact('\u0022')));
            var allCharacters = new OneOrMore(new Ranges('\u0020', '\uFFFF'));
            var escapeCharacters = new Many(new Any(" \\\"\b\f\r\n\t"));
            var hex = new Choices(
                new Ranges('0', '9'),
                new Ranges('a', 'f'),
                new Ranges('A', 'F'));
            var unicodeCharacters = new Many(new Sequance(
                new Charact('\\'),
                new Charact('u'),
                new Sequance(
                    hex,
                    hex,
                    hex,
                    hex)));

            var characters = new Sequance(allCharacters, escapeCharacters, unicodeCharacters);
            pattern = new Choices(
                new Many(characters),
                forbidenCharacters);
        }

        public IMatch Match(string text)
        {
            return pattern.Match(text);
        }
    }
}
