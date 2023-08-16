using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private string heroName = "Mario";
    private int heroLevel = 4;

    [Test]
    public void ConstructorShouldWork()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateShouldSuccessWithValidHero()
    {
        Hero hero = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.AreEqual(1, heroRepository.Heroes.Count);
    }

    [Test]
    public void CreateShouldThrowWithNullHero()
    {
        Hero hero = null;
        HeroRepository heroRepository = new HeroRepository();

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void CreateShouldThrowWithExistantHero()
    {
        Hero hero = new Hero(heroName, heroLevel);
        Hero hero2 = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero2);
        });
    }

    [Test]
    public void CreateShouldThrowWithSameHero()
    {
        Hero hero = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.Throws<InvalidOperationException>(() =>
        {
            heroRepository.Create(hero);
        });
    }

    [Test]
    public void RemoveShouldSuccessWithExistantHero()
    {
        Hero hero = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        bool isRemoved = heroRepository.Remove(heroName);

        Assert.IsTrue(isRemoved);
        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }

    [TestCase(null)]
    [TestCase("      ")]
    public void RemoveShouldThrowWithNullOrWhiteSpaceHeroName(string name)
    {
        Hero hero = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero);

        Assert.Throws<ArgumentNullException>(() =>
        {
            heroRepository.Remove(name);
        });
    }

    [Test]
    public void GetHeroWithHighestLevelShouldSuccessWithMultipleHeroesWithDifferentLevels()
    {
        Hero hero1 = new Hero(heroName, heroLevel);
        Hero hero2 = new Hero("Peter", 2);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero1);
        heroRepository.Create(hero2);

        Hero heroWithHighestLevel = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(hero1.Name, heroWithHighestLevel.Name);
        Assert.AreEqual(hero1.Level, heroWithHighestLevel.Level);
    }

    [Test]
    public void GetHeroWithHighestLevelShouldSuccessWithMultipleHeroesWithSameLevels()
    {
        Hero hero2 = new Hero("Peter", 4);
        Hero hero1 = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero2);
        heroRepository.Create(hero1);

        Hero heroWithHighestLevel = heroRepository.GetHeroWithHighestLevel();

        Assert.AreEqual(hero2.Name, heroWithHighestLevel.Name);
        Assert.AreEqual(hero2.Level, heroWithHighestLevel.Level);
    }

    [Test]
    public void GetHeroShouldSuccessWithMultipleHeroes()
    {
        Hero hero2 = new Hero("Peter", 4);
        Hero hero1 = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero2);
        heroRepository.Create(hero1);

        Hero receivedHero = heroRepository.GetHero(hero1.Name);

        Assert.AreEqual(hero1.Name, receivedHero.Name);
        Assert.AreEqual(hero1.Level, receivedHero.Level);
    }

    [Test]
    public void GetHeroShouldSuccessWithNoHeroes()
    {
        HeroRepository heroRepository = new HeroRepository();

        Hero receivedHero = heroRepository.GetHero(heroName);

        Assert.IsNull(receivedHero);
    }

    [Test]
    public void HeroesShouldSuccessWithMultipleHeroes()
    {
        Hero hero2 = new Hero("Peter", 4);
        Hero hero1 = new Hero(heroName, heroLevel);
        HeroRepository heroRepository = new HeroRepository();

        heroRepository.Create(hero2);
        heroRepository.Create(hero1);

        Assert.AreEqual(2, heroRepository.Heroes.Count);
    }

    [Test]
    public void HeroesShouldSuccessWithNoHeroes()
    {
        HeroRepository heroRepository = new HeroRepository();

        Assert.AreEqual(0, heroRepository.Heroes.Count);
    }
}