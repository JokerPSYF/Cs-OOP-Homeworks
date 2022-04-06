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
            Assert.AreEqual(0,stage.Performers.Count);
        }
        
        [Test]
	    public void AddPerfomereThrowException()
        {
            Stage stage = new Stage();
            Assert.AreEqual(0,stage.Performers.Count);
        }
        
        [Test]
	    public void CtorsTest()
        {
            Stage stage = new Stage();
            Assert.AreEqual(0,stage.Performers.Count);
        }

	}
}