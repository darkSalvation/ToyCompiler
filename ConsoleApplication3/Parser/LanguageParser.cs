using System;
using System.Collections.Generic;
using ToyCompiler.Model;

namespace ToyCompiler.Parser
{
    public class LanguageParser
    {
        private List<Token> _tokens;
        private int _index;

        public int Parse(List<Token> tokens)
        {
            _tokens = tokens;


            while (Current.Typ != TokenTyp.Eof)
            {
                switch (Current.Typ)
                {
                    case TokenTyp.Add: 
                        Consume();
                        return ParseAdd(); 
                }

                Consume();
            }

            return 0;
        }

        private int ParseAdd()
        {
            if(!Take(TokenTyp.OpenParenthesis))
                return 0;

            int a = 0;
            int b = 0;

            a = ParserAddExp();
            Take(TokenTyp.Comma);
            b = ParserAddExp();

            Console.WriteLine(a+b);

            return a + b;
        }

        private int ParserAddExp()
        {
            int a = 0;
            int b = 0;

            Token nextToken = Peek(0);

            switch (nextToken.Typ)
            {
                case TokenTyp.Add:
                    Consume();
                    Take(TokenTyp.OpenParenthesis);
                    a = ParserAddExp();
                    Take(TokenTyp.Comma);
                    b = ParserAddExp();
                    Take(TokenTyp.CloseParenthesis);
                    return a + b;

                case TokenTyp.Number:
                    Consume();
                    return Convert.ToInt32(nextToken.Value);
            }

            throw new Exception(String.Format("Expected ADD OR NUMBER but got {0}", nextToken.Typ));
        }

        private int ParseNumber()
        {
            Token token = Current;

            if (Take(TokenTyp.Number))
            {
                return Convert.ToInt32(token.Value);
            }

            return 0;
        }

        private Boolean Take(TokenTyp token)
        {
            if (Eof(0))
            {
                throw new Exception(String.Format("Expected {0} but found: {1}", Current.Typ, token));
            }

            if (_tokens[_index].Typ == token)
            {
                Consume();
                return true;
            }

            return false;
        }

        private Token Peek(int numberOfTokens)
        {
            if (Eof(numberOfTokens))
            {
                return new Token {Typ = TokenTyp.Eof};
            }

            return _tokens[_index + numberOfTokens];
        }

        private Token Current
        {
            get
            {
                if (Eof(0))
                {
                    return new Token { Typ = TokenTyp.Eof};
                }
                return _tokens[_index];
            }
        }

        private void Consume()
        {
            _index++;
        }


        private Boolean Eof(int numberOfTokens)
        {
            return _index + numberOfTokens >= _tokens.Count;
        }
    }
}