using System;
using System.Text.RegularExpressions;

namespace ToyCompiler.Model
{
    public class TokenDefinition
    {
        public Regex Regex { get; set; }
        public TokenTyp Type { get; set; }
        public Boolean IsIgnored { get; set; }

        public TokenMatch Match(string input, int index)
        {
            Match match = Regex.Match(input, index);
            if (match.Success && match.Index == index)
            {
                return new TokenMatch
                {
                    IsMatch = true,
                    TokenTyp = Type,
                    Value = match.Value,
                };
            }

            return new TokenMatch {IsMatch = false};
        }
    }

}