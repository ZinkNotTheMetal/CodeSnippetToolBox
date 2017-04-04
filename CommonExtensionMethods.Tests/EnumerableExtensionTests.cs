using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CommonExtensionMethods.Tests
{
    [TestFixture]
    public class EnumerableExtensionTests
    {
        public class TestClass
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        [Test]
        public void CountInstances_WhenNullInput_ShouldThrowException()
        {
            List<int> input = null;
            Assert.Throws<ArgumentNullException>(() => input.CountInstances());
        }

        [Test]
        public void CountInstances_WhenSingleInstanceInList_ShouldReturnCorrectDictionary()
        {
            List<int> input = new List<int>();
            input.Add(3);
            var result = input.CountInstances();

            Assert.IsNotNull(result);
            Assert.That(result.Keys.First(), Is.EqualTo(3));
            Assert.That(result.Values.First(), Is.EqualTo(1)); //the amount of times it showed up
        }

        [Test]
        public void CountIntances_WhenEmptyList_ShouldReturnEmptyDictionary()
        {
            List<int> input = new List<int>();
            var result = input.CountInstances();

            Assert.IsNotNull(result);
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void CountIntances_WhenMultipleInstances_ShouldReturnCorrectDictionary()
        {
            List<string> input = new List<string>
            {
                "Test",
                "var",
                "list",
                "Test",
                "Test",
                "list"
            };

            var result = input.CountInstances();

            Assert.IsNotNull(result);
            Assert.That(result.Keys.Contains("Test"));
            Assert.That(result.Keys.Contains("var"));
            Assert.That(result.Keys.Contains("list"));

            Assert.That(result["Test"], Is.EqualTo(3));
            Assert.That(result["var"], Is.EqualTo(1));
            Assert.That(result["list"], Is.EqualTo(2));
        }

        [Test]
        public void DistinctBy_WhenDistinctingById_ShouldReturnAllElements()
        {
            List<TestClass> input = new List<TestClass>();
            input.Add(new TestClass { Id = 1, Name = "William" });
            input.Add(new TestClass { Id = 2, Name = "William" });
            input.Add(new TestClass { Id = 3, Name = "William" });

            //Return only distinct items by name
            var result = input.DistinctBy(x => x.Id);

            Assert.IsNotNull(result);
            Assert.That(3, Is.EqualTo(result.Count()));
        }

        [Test]
        public void DistinctBy_WhenDistinctingByName_ShouldReturnOneElement()
        {
            List<TestClass> input = new List<TestClass>();
            input.Add(new TestClass { Id = 1, Name = "William" });
            input.Add(new TestClass { Id = 2, Name = "William" });
            input.Add(new TestClass { Id = 3, Name = "William" });

            //Return only distinct items by name
            var result = input.DistinctBy(x => x.Name);

            Assert.IsNotNull(result);
            Assert.That(result.Count(), Is.EqualTo(1));
        }

        [Test]
        public void ShuffleElements_WhenValidList_ShouldReturnValidList()
        {
            List<TestClass> input = new List<TestClass>();
            input.Add(new TestClass { Id = 1, Name = "William" });
            input.Add(new TestClass { Id = 2, Name = "Bob" });
            input.Add(new TestClass { Id = 3, Name = "Khal" });
            input.Add(new TestClass { Id = 4, Name = "Christie" });
            input.Add(new TestClass { Id = 5, Name = "Me" });

            var result = input.ShuffleElements();

            Assert.That(!input.SequenceEqual(result), Is.True);
        }

        [Test]
        public void TakeUntil_WhenValidEndCondition_ShouldReturnSubList()
        {
            List<TestClass> input = new List<TestClass>();
            input.Add(new TestClass { Id = 1, Name = "William" });
            input.Add(new TestClass { Id = 2, Name = "Bob" });
            input.Add(new TestClass { Id = 3, Name = "Khal" });
            input.Add(new TestClass { Id = 4, Name = "Christie" });
            input.Add(new TestClass { Id = 5, Name = "Me" });

            var result = input.TakeUntil(x => x.Name == "Khal").ToList();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Has.Count.EqualTo(2));
        }
    }
}