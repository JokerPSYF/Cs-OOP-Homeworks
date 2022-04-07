// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 

using FestivalManager.Entities;

namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class StageTests
    {
        [Test]
        public void CtorTest()
        {
            Stage stage = new Stage();
            Assert.AreEqual(0, stage.Performers.Count);
        }

        [Test]
        public void AddPerfomerThrowException()
        {
            Stage stage = new Stage();
            Performer performer = new Performer("Todor", "Vasilev", 16);

            Assert.Throws<ArgumentException>(() => stage.AddPerformer(performer));
        }

        [Test]
        public void AddPerfomerSucccess()
        {
            Performer performer1 = new Performer("Todor", "Vasilev", 18);
            Performer performer2 = new Performer("Mitko", "Peveca", 19);
            Performer performer3 = new Performer("Ico", "Shamara", 99);
            Stage stage = new Stage();
            stage.AddPerformer(performer1);
            stage.AddPerformer(performer2);
            stage.AddPerformer(performer3);

            Assert.AreEqual(3, stage.Performers.Count);
        }

        [Test]
        public void AddSong_ThrowsException()
        {
            Stage stage = new Stage();

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(50));

            Assert.Throws<ArgumentException>(() => stage.AddSong(song));
        }

        [Test]
        public void AddSong_PositiveTest()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddPerformer(performer1);

            Assert.DoesNotThrow(() => stage.AddSong(song));
        }

        [Test]
        public void AddSongToPerformer_PositiveTest()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddPerformer(performer1);

            stage.AddSong(song);

            string result = stage.AddSongToPerformer(song.Name, performer1.FullName);

            Assert.AreEqual
                ("Ketchup Mayonesa (01:50) will be performed by Todor Vasilev"
                    , result);
        }


        [Test]
        public void Play_PositiveTest()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddPerformer(performer1);

            stage.AddSong(song);

            stage.AddSongToPerformer(song.Name, performer1.FullName);

            string result = stage.Play();

            Assert.AreEqual
                ("1 performers played 1 songs"
                    , result);
        }

        [Test]
        public void GetPerfomer_ThrowException()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddPerformer(performer1);

            stage.AddSong(song);

            Assert.Throws<ArgumentException>
                (() => stage.AddSongToPerformer("Kukata", performer1.FullName));
        }

        [Test]
        public void GetSong_ThrowException()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddPerformer(performer1);

            stage.AddSong(song);

            Assert.Throws<ArgumentException>
                (() => stage.AddSongToPerformer(song.Name, "performer1.FullName"));
        }

        [Test]
        public void ValidateValue_ThrowException()
        {
            Stage stage = new Stage();

            Performer performer1 = new Performer("Todor", "Vasilev", 18);

            Song song = new Song("Ketchup Mayonesa", new TimeSpan(0, 1, 50));

            stage.AddSong(song);

            Assert.Throws<ArgumentNullException>
                (() => stage.AddPerformer(null));
        }

    }
}