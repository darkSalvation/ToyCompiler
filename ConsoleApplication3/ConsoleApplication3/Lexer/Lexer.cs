using System;
using System.Collections.Generic;
using ConsoleApplication3.Model;

namespace ConsoleApplication3.Lexer
{
    public class Lexer 
    {
        private readonly List<TokenDefinition> _tokenDefinitions = new List<TokenDefinition>(); 

        public void AddDefinition(TokenDefinition tokenDefinition)
        {
            if (tokenDefinition == null) throw new ArgumentNullException("tokenDefinition");

            _tokenDefinitions.Add(tokenDefinition);
        }

        public IEnumerable<Token> Tokenize(String input)
        {
            int index = 0;

            while (index < input.Length)
            {
                var match = FindMatch(input, index);
                if (match.IsMatch)
                {
                    yield return new Token {Value = match.Value, Typ = match.TokenTyp};
                    index += match.Value.Length;
                }
                else
                {
                    index++;
                }
            }
        }

        private TokenMatch FindMatch(string input, int index)
        {
            foreach (var tokenDefinition in _tokenDefinitions)
            {
                var match = tokenDefinition.Match(input, index);
                if (match.IsMatch)
                {
                    return match;
                }
            }

            return new TokenMatch {IsMatch = false};
        }
    }
}