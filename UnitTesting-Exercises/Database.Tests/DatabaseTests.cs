using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [Test]
        public void WhenYouAddMoreThan16ElementsShouldThrowException()
        {
            Database db = new Database();

            for (int i = 0; i < 16; i++)
            {
                db.Add(i);
            }

            Assert.AreEqual(16, db.Count);

            Assert.Throws<InvalidOperationException>(() => db.Add(17), "You shouldn't can to add 17 elements");
        }

        [Test]
        public void WhenYouRemoveAnElementShouldTheLastElementBeenRemoved()
        {
            Database db = new Database();

            for (int i = 0; i < 6; i++)
            {
                db.Add(i);
            }

            int[] arr = new[] {0, 1, 2, 3, 4};

            db.Remove();

            int[] fetch = db.Fetch();

            Assert.AreEqual(arr, fetch);

            Database secDb = new Database();

            Assert.Throws<InvalidOperationException>(() => secDb.Remove());
        }

        [Test]
        public void FetchShouldReturnArray()
        {
            Database db = new Database(1, 2, 3, 4, 5);

            int[] arr = new int[] { };

            Type arrType = arr.GetType();

            Type typeDb = db.Fetch().GetType();

            Assert.AreEqual(arrType, typeDb);
        }
        
        [Test]
        public void CtorShouldTakeLessthan16Integers()
        {
            Database db = new Database();
            Assert.Throws<InvalidOperationException>
                (() => db = new Database(1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17));
        }
    }
}
