using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ConsoleApplication3.Model;
using ConsoleApplication3.Parser;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            Lexer.Lexer lexer = new Lexer.Lexer();

            lexer.AddDefinition(new TokenDefinition {Regex = new Regex("[Aa][Dd][Dd]"), Type = TokenTyp.Add});
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\("), Type = TokenTyp.OpenParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\)"), Type = TokenTyp.CloseParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(","), Type = TokenTyp.Comma });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d"), Type = TokenTyp.Digit });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace });

            LanguageParser parser = new LanguageParser();
            parser.Parse(lexer.Tokenize("ADD(1,2").ToList());

            Console.Read();
        }
    }

}
