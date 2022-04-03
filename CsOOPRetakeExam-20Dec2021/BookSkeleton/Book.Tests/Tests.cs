namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book1;
        private Book book2;
        [SetUp]
        public void SetUp()
        {
            book1 = new Book("Metro2030", "Dmitri");
            book2 = new Book("OrientExpress", "Agatha");
        }

        [Test]
        public void Ctor_BookName_Test()
        {
            Assert.AreEqual("Metro2030", book1.BookName);
        }
        
        [Test]
        public void Ctor_Author_Test()
        {
            Assert.AreEqual("Agatha", book2.Author);
        }
        
        [Test]
        public void Ctor_FootNote_Test()
        {
            Assert.AreEqual(0, book1.FootnoteCount);
            Assert.AreEqual(0, book2.FootnoteCount);
        }

        [Test]
        public void BookName_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Book(null, "Dmitri"));
        }
        
        [Test]
        public void Author_Throw_Exception()
        {
            Assert.Throws<ArgumentException>(() => new Book("Metro2033", null));
        }

        [Test]
        public void AddFootNote_Throws_Exception_When_Add_Two_Times_Same_Note()
        {
            book1.AddFootnote(32, "Artiom Go");

            Assert.Throws<InvalidOperationException>(() => book1.AddFootnote(32, "Now"));
        }
        
        [Test]
        public void AddFootNote_Work()
        {
            book1.AddFootnote(32, "Artiom Go");

            book1.AddFootnote(34, "Now");

            Assert.AreEqual(2, book1.FootnoteCount);
        }
        
        [Test]
        public void FindFootNote_Cant_Find_Note()
        {
            book1.AddFootnote(32, "Artiom Go");

            book1.AddFootnote(34, "Now");

            Assert.Throws<InvalidOperationException>(() => book1.FindFootnote(33));
        }
        
        [Test]
        public void FindFootNote_Works()
        {
            book1.AddFootnote(32, "Artiom Go");

            book1.AddFootnote(34, "Now");

            Assert.AreEqual("Footnote #32: Artiom Go", book1.FindFootnote(32));
        }

        [Test]
        public void AlterFootNote_Cant_Find_Note()
        {
            book1.AddFootnote(32, "Artiom Go");

            book1.AddFootnote(34, "Now");

            Assert.Throws<InvalidOperationException>(() => book1.AlterFootnote(33, "Stay"));
        }

        [Test]
        public void AlterFootNote_Works()
        {
            book1.AddFootnote(32, "Artiom Go");

            book1.AddFootnote(34, "Now");

            book1.AlterFootnote(34, "There");

            Assert.AreEqual("Footnote #34: There", book1.FindFootnote(34));
        }
    }
}