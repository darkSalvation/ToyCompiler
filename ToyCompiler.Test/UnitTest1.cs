using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToyCompiler.Model;
using ToyCompiler.Parser;

namespace ToyCompiler.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Lexer.Lexer lexer = new Lexer.Lexer();

            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("[Aa][Dd][Dd]"), Type = TokenTyp.Add });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\("), Type = TokenTyp.OpenParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\)"), Type = TokenTyp.CloseParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(","), Type = TokenTyp.Comma });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d+"), Type = TokenTyp.Number });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace, IsIgnored = true });

            LanguageParser parser = new LanguageParser();
            int res = parser.Parse(lexer.Tokenize("ADD(ADD(1,ADD(1,3)) ,23").ToList());
            Assert.AreEqual(res, 28);
        }

        [TestMethod]
        public void TestMethod2()
        {
            Lexer.Lexer lexer = new Lexer.Lexer();

            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("[Aa][Dd][Dd]"), Type = TokenTyp.Add });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\("), Type = TokenTyp.OpenParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\)"), Type = TokenTyp.CloseParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(","), Type = TokenTyp.Comma });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d+"), Type = TokenTyp.Number });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace, IsIgnored = true });

            LanguageParser parser = new LanguageParser();
            int res = parser.Parse(lexer.Tokenize("ADD(1, ADD(2,3))").ToList());
            Assert.AreEqual(res, 6);
        }

        [TestMethod]
        public void TestMethod3()
        {
            Lexer.Lexer lexer = new Lexer.Lexer();

            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("[Aa][Dd][Dd]"), Type = TokenTyp.Add });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\("), Type = TokenTyp.OpenParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\)"), Type = TokenTyp.CloseParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(","), Type = TokenTyp.Comma });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d+"), Type = TokenTyp.Number });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace, IsIgnored = true });

            LanguageParser parser = new LanguageParser();
            int res = parser.Parse(lexer.Tokenize("ADD(ADD(1,ADD(1,3)) ,ADD(1,5)").ToList());
            Assert.AreEqual(res, 11);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestMethod4()
        {
            Lexer.Lexer lexer = new Lexer.Lexer();

            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("[Aa][Dd][Dd]"), Type = TokenTyp.Add });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\("), Type = TokenTyp.OpenParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex("\\)"), Type = TokenTyp.CloseParenthesis });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(","), Type = TokenTyp.Comma });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\d+"), Type = TokenTyp.Number });
            lexer.AddDefinition(new TokenDefinition { Regex = new Regex(@"\s+"), Type = TokenTyp.Whitespace, IsIgnored = true });

            LanguageParser parser = new LanguageParser();
            int res = parser.Parse(lexer.Tokenize("ADD(12)").ToList());
            Assert.AreEqual(res, 11);
        }

    }
}
