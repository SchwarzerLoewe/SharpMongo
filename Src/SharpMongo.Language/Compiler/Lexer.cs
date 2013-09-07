﻿namespace SharpMongo.Language.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Lexer
    {
        private string text;

        public Lexer(string text)
        {
            this.text = text;
        }

        public Token NextToken()
        {
            if (this.text == null)
                return null;

            var token = new Token(this.text, TokenType.Name);
            this.text = null;

            return token;
        }
    }
}
