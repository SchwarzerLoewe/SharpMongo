﻿namespace SharpMongo.Language.Tests.Compiler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SharpMongo.Language.Compiler;

    [TestClass]
    public class LexerTests
    {
        [TestMethod]
        public void GetName()
        {
            Lexer lexer = new Lexer("db");

            var result = lexer.NextToken();

            Assert.IsNotNull(result);
            Assert.AreEqual("db", result.Value);
            Assert.AreEqual(TokenType.Name, result.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNameWithSpaces()
        {
            Lexer lexer = new Lexer("  db   ");

            var result = lexer.NextToken();

            Assert.IsNotNull(result);
            Assert.AreEqual("db", result.Value);
            Assert.AreEqual(TokenType.Name, result.Type);

            Assert.IsNull(lexer.NextToken());
        }

        [TestMethod]
        public void GetNames()
        {
            Lexer lexer = new Lexer("show dbs");

            var result = lexer.NextToken();

            Assert.IsNotNull(result);
            Assert.AreEqual("show", result.Value);
            Assert.AreEqual(TokenType.Name, result.Type);

            result = lexer.NextToken();

            Assert.IsNotNull(result);
            Assert.AreEqual("dbs", result.Value);
            Assert.AreEqual(TokenType.Name, result.Type);

            Assert.IsNull(lexer.NextToken());
        }
    }
}
