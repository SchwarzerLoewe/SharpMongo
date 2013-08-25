﻿namespace SharpMongo.Core.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PeopleCollectionTests
    {
        private Collection collection;
        private DynamicDocument adam;
        private DynamicDocument eve;
        private DynamicDocument abel;
        private DynamicDocument cain;

        [TestInitialize]
        public void Setup()
        {
            this.collection = new Collection();

            this.adam = new DynamicDocument("Name", "Adam", "Age", 800);
            this.eve = new DynamicDocument("Name", "Eve", "Age", 700);
            this.cain = new DynamicDocument("Name", "Cain", "Age", 600);
            this.abel = new DynamicDocument("Name", "Abel", "Age", 500);

            this.collection.Insert(this.adam);
            this.collection.Insert(this.eve);
            this.collection.Insert(this.cain);
            this.collection.Insert(this.abel);
        }

        [TestMethod]
        public void IdsInDocuments()
        {
            Assert.IsNotNull(this.adam.Id);
            Assert.IsNotNull(this.eve.Id);
            Assert.IsNotNull(this.cain.Id);
            Assert.IsNotNull(this.abel.Id);
        }

        [TestMethod]
        public void UpdateAgeInOneDocument()
        {
            this.collection.Update(new DynamicDocument("Id", this.eve.Id), new DynamicDocument("Age", 600));

            var result = this.collection.Find(new DynamicDocument("Id", this.eve.Id));

            Assert.AreEqual(1, result.Count());

            Assert.AreEqual(this.eve.Id, result.First().GetMember("Id"));
            Assert.AreEqual("Eve", result.First().GetMember("Name"));
            Assert.AreEqual(600, result.First().GetMember("Age"));

            result = this.collection.Find(new DynamicDocument("Id", this.adam.GetMember("Id")));

            Assert.AreEqual(1, result.Count());

            Assert.AreEqual(this.adam.Id, result.First().GetMember("Id"));
            Assert.AreEqual("Adam", result.First().GetMember("Name"));
            Assert.AreEqual(800, result.First().GetMember("Age"));
        }

        [TestMethod]
        public void UpdateAgeInAllDocuments()
        {
            this.collection.Update(new DynamicDocument(), new DynamicDocument("Age", 600), true);

            var result = this.collection.Find();

            Assert.AreEqual(4, result.Count());

            foreach (var document in result)
                Assert.AreEqual(600, document.GetMember("Age"));
        }

        [TestMethod]
        public void UpdateAgeInAllDocumentsUsingNullQuery()
        {
            this.collection.Update(null, new DynamicDocument("Age", 600), true);

            var result = this.collection.Find();

            Assert.AreEqual(4, result.Count());

            foreach (var document in result)
                Assert.AreEqual(600, document.GetMember("Age"));
        }
    }
}
