using System;

namespace ConsoleApplication3.Model
{
    public class TokenMatch
    {
        public Boolean IsMatch { get; set; }
        public TokenTyp TokenTyp { get; set; }
        public String Value { get; set; }
        public String RemainingText { get; set; }


    }
}