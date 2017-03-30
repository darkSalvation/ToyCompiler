using System;
using System.Linq;
using System.Text.RegularExpressions;
using ToyCompiler.Model;
using ToyCompiler.Parser;

namespace ToyCompiler
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
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d+"), Type = TokenTyp.Number });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace, IsIgnored = true});

            LanguageParser parser = new LanguageParser();
            parser.Parse(lexer.Tokenize("ADD(ADD(1,ADD(1,3)) ,23").ToList());
            //parser.Parse(lexer.Tokenize("ADD(1,23").ToList());

            Console.Read();
        }
    }

}
