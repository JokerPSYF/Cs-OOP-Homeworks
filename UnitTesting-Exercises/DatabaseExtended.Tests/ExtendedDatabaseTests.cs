using System;
using System.Collections.Generic;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void CtorShouldTakeLessThan16Persons()
        {
            List<Person> personList = new List<Person>();

            for (int i = 0; i < 17; i++)
            {
                personList.Add(new Person(i, $"{i}"));
            }

            Database db = new Database();

            Assert.Throws<ArgumentException>(() => db = new Database(personList.ToArray()));
        }
        
        [Test]
        public void CtorShouldMakeNewDataBaseSuccesfull()
        {
            Database db = new Database(new Person(2, "2"));

            Assert.AreEqual(1, db.Count);
        }

        [Test]
        public void WhenYouAddMoreThan17PersonsThrowException()
        {
            Database db = new Database();

            for (int i = 0; i < 16; i++)
            {
                db.Add(new Person(i, $"{i}"));
            }


            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(16, "16")));
        }
        
        [Test]
        public void AddPersons()
        {
            Database db2 = new Database();

            for (int i = 0; i < 16; i++)
            {
                db2.Add(new Person(i, $"{i}"));
            }

            Assert.AreEqual(16, db2.Count);
        }

        [TestCase(1,"1", 1, "2")]
        [TestCase(1,"1", 2, "1")]
        [TestCase(1,"1", 1, "1")]
        public void AddShouldThrowsException(int id1, string name1, int id2, string name2 )
        {
            Database db = new Database(new Person(id1, name1));

            Assert.Throws<InvalidOperationException>(() => db.Add(new Person(id2, name2)));
        }

        [Test]
        public void WhenYouRemoveFromEmptyClassShouldthrowException()
        {
            Database secDb = new Database();

            Assert.Throws<InvalidOperationException>(() => secDb.Remove());
        }

        [Test]
        public void WhenYouRemoveFromDataBaseCountShouldDecrease()
        {
            Database secDb = new Database(new Person(1, "1"));

            secDb.Remove();
            
            Assert.AreEqual(0, secDb.Count);
        }

        [Test]
        public void FindByUserNameThrowsExceptions()
        {
            Database db = new Database(new Person(1, "1q"));

            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(""));
            Assert.Throws<ArgumentNullException>(() => db.FindByUsername(string.Empty));
            Assert.Throws<InvalidOperationException>(() => db.FindByUsername("pesho"));
            Assert.DoesNotThrow(() => db.FindByUsername("1q"));
        }
        
        [Test]
        public void FindByIDThrowsExceptions()
        {
            Database db = new Database(new Person(long.MaxValue, "1"));

            Assert.Throws<ArgumentOutOfRangeException>(() => db.FindById(-1));
            Assert.Throws<InvalidOperationException>(() => db.FindById(2));
            Assert.DoesNotThrow(() => db.FindById(long.MaxValue));
        }

        [Test]
        public void CountShouldGiveTheCountOfElements()
        {
            Database db = new Database();

            for (int i = 0; i < 15; i++)
            {
                db.Add(new Person(i, $"{i}"));
            }

            Assert.AreEqual(15, db.Count);
        }

        //[Test]
        //public void ConstructorShoudInitializeCollection()
        //{
        //    var expected = new Person[] { new Person(pesho), gosho };

        //    var db = new Database(expected);

        //    var actual = expected;

        //    Assert.That(actual, Is.EqualTo(expected));
        //}

    }
}