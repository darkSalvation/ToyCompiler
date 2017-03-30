using System.Text.RegularExpressions;

namespace ConsoleApplication3.Model
{
    public class TokenDefinition
    {
        public Regex Regex { get; set; }
        public TokenTyp Type { get; set; }

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