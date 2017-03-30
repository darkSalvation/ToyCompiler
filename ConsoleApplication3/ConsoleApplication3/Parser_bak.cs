using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApplication3.Model;

namespace ConsoleApplication3
{
    public class Parser_bak
    {
        private int _index = 0;

        public void Parse(List<Token> tokens)
        {
            while (true)
            {
                if (tokens[_index].Typ == TokenTyp.Add)
                {
                    int summe = Add(tokens, _index);
                    Console.WriteLine(summe);
                }

                break;
            }
        }

        private static int Add(List<Token> tokens, int i)
        {
            int summandA = 0;
            int summandB = 0;

            switch (tokens[i + 1].Typ)
            {
                case TokenTyp.Number:
                    summandA = Convert.ToInt32(tokens[i +1].Value);
                    break;
                case TokenTyp.Add:
                    summandA = Add(tokens, i + 3);
                    break;
            }

            switch (tokens.ElementAt(i + 2).Typ)
            {
                case TokenTyp.Number:
                    summandB = Convert.ToInt32(tokens[i + 2].Value);
                    break;
                case TokenTyp.Add:
                    summandB = Add(tokens, i + 2);
                    break;
            }

            int summe = summandA + summandB;
            return summe;
        }


    }
}