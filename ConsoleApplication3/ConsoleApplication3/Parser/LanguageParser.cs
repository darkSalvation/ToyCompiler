using System;
using System.Collections.Generic;
using ConsoleApplication3.Model;

namespace ConsoleApplication3.Parser
{
    public class LanguageParser
    {
        public void Parse(List<Token> tokens)
        {
            foreach (Token token in tokens)
            {
                if (token.Typ == TokenTyp.Add)
                {
                    
                }
            }
        }
    }
}