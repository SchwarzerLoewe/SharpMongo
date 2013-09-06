﻿namespace SharpMongo.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class DocumentBaseTests
    {
        [TestMethod]
        public void CreateWithName()
        {
            DocumentBase dbase = new DocumentBase("Test");

            Assert.AreEqual("Test", dbase.Name);
        }

        [TestMethod]
        public void GetNonExistentCollection()
        {
            DocumentBase dbase = new DocumentBase("Test");

            Assert.IsNull(dbase.GetCollection("Unknown"));
        }

        [TestMethod]
        public void CreateCollection()
        {
            DocumentBase dbase = new DocumentBase("Test");

            var collection = dbase.CreateCollection("People");

            Assert.IsNotNull(collection);
            Assert.AreEqual("People", collection.Name);

            Assert.AreSame(collection, dbase.GetCollection("People"));
        }

        [TestMethod]
        public void CreateCollectionTwice()
        {
            DocumentBase dbase = new DocumentBase("Test");

            dbase.CreateCollection("People");

            try
            {
                dbase.CreateCollection("People");
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(InvalidOperationException));
                Assert.AreEqual("Collection 'People' already exists", ex.Message);
            }
        }
    }
}
