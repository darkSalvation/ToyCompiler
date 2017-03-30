using System;

namespace ConsoleApplication3.Model
{
    public class Token
    {
        public TokenTyp Typ { get; set; }
        public String Value { get; set; }

        public override string ToString()
        {
            return string.Format("Typ: {0}, Value: {1}", Typ, Value);
        }
    }
}