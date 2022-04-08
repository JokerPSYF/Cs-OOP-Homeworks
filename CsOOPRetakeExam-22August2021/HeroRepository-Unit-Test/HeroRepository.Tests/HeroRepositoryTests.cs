using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    [Test]
    public void HeroCtorCheck()
    {
        Hero hero = new Hero("Batman", 99);

        Assert.AreEqual("Batman", hero.Name);
        Assert.AreEqual(99, hero.Level);
    }

    [Test]
    public void HeroRepositoryCtorCheck()
    {
        HeroRepository heroes = new HeroRepository();

        Assert.AreEqual(0, heroes.Heroes.Count);
    }

    [Test]
    public void CreateNullHero_MustThrowException()
    {
        HeroRepository heroes = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() => heroes.Create(null));
    }

    [Test]
    public void CreateCteatedHero_MustThrowException()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero = new Hero("Batman", 99);

        heroes.Create(hero);

        Assert.Throws<InvalidOperationException>(() => heroes.Create(hero));
    }

    [Test]
    public void CreateMethod_PosotiveTest()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero = new Hero("Batman", 99);

        string result = heroes.Create(hero);

        Assert.AreEqual("Successfully added hero Batman with level 99", result);
    }

    [Test]
    public void Remove_MustThrowException()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero = new Hero("Batman", 99);

        string result = heroes.Create(hero);

        Assert.Throws<ArgumentNullException>(() => heroes.Remove(" "));
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(""));
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(null));
        Assert.Throws<ArgumentNullException>(() => heroes.Remove(string.Empty));

    }

    [Test]
    public void Remove_PositiveTest()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero = new Hero("Batman", 99);

        heroes.Create(hero);

        bool result = heroes.Remove("Batman");
        bool result1 = heroes.Remove("Superman");

        Assert.AreEqual(true, result);
        Assert.AreEqual(false, result1);
    }
    
    [Test]
    public void GetHeroWithHighestLevel_PositiveTest()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero1 = new Hero("Batman", 100);
        Hero hero2 = new Hero("Superman", 95);
        Hero hero3 = new Hero("Raven", 80);
        Hero hero4 = new Hero("Flash", 80);

        heroes.Create(hero1);
        heroes.Create(hero2);
        heroes.Create(hero3);
        heroes.Create(hero4);

        Hero bestHero = heroes.GetHeroWithHighestLevel();

        Assert.AreEqual(hero1, bestHero);
    }
    
    [Test]
    public void GetHero_ReturnNull()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero1 = new Hero("Batman", 100);
        Hero hero2 = new Hero("Superman", 95);
        Hero hero3 = new Hero("Raven", 80);
        Hero hero4 = new Hero("Flash", 80);

        heroes.Create(hero1);
        heroes.Create(hero2);
        heroes.Create(hero3);
        heroes.Create(hero4);

        Hero bestHero = heroes.GetHero("Sprider-Man");

        Assert.AreEqual(null, bestHero);
    }
    
    [Test]
    public void GetHero_ReturnHero()
    {
        HeroRepository heroes = new HeroRepository();

        Hero hero1 = new Hero("Batman", 100);
        Hero hero2 = new Hero("Superman", 95);
        Hero hero3 = new Hero("Raven", 80);
        Hero hero4 = new Hero("Flash", 80);

        heroes.Create(hero1);
        heroes.Create(hero2);
        heroes.Create(hero3);
        heroes.Create(hero4);

        Hero bestHero = heroes.GetHero("Flash");

        Assert.AreEqual(hero4, bestHero);
    }
}