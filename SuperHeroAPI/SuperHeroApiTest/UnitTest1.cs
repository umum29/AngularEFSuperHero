using NUnit.Framework;
using SuperHeroAPI.Data;
using SuperHeroAPI.Models;
using SuperHeroAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore;

namespace SuperHeroApiTest;

[TestFixture]
public class Tests
{
    [SetUp]
    public void Setup()
    {
     
    }

    [Test]
    //MethodName_StateUnderTest_ExpectedBehavior
    public async Task GetHero__ShouldReturn_OKAndSuperHero()
    {
        //Arrange
        //1.Set up In-Memory DB
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "SuperHero")
            .Options;

        // Insert seed data into the database using one instance of the context
        using (var context = new DataContext(options))
        {
            var heroes = new SuperHero[]
            {
                new SuperHero { Name = "SpiderMan", FirstName ="Peter", LastName = "Parker", Place="New York"},
                new SuperHero { Name = "IronMan", FirstName ="Tony", LastName = "Stark", Place="California"},
                new SuperHero { Name = "CapitainAmerica", FirstName ="Steve", LastName = "Keer", Place="New York"}
            };

            context.SuperHeroes.AddRange(heroes);
            context.SaveChanges();
        }

        using (var context = new DataContext(options))
        {
            var superHeroController = new SuperHeroController(context);
            //Act
            var result = await superHeroController.GetSuperheroes();
            var okResult = result.Result as OkObjectResult;
            List<SuperHero> heroes = (List<SuperHero>)okResult.Value;
            //List<SuperHero> heroes = result.Result as List<SuperHero>;
            //Assert
            Assert.AreEqual(3, heroes.Count);
        }
    }
    [Test]
    //MethodName_StateUnderTest_ExpectedBehavior
    public async Task PostHero__ShouldReturn_OK()
    {
        //Arrange
        //1.Set up In-Memory DB
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: "SuperHero")
            .Options;

        using (var context = new DataContext(options))
        {
            var superHeroController = new SuperHeroController(context);
            //Act
            var hero = new SuperHero() { Name = "TestHero", LastName = "LastName", FirstName = "FirstName", Place = "Taiwan" };
            var result = await superHeroController.CreateSuperhero(hero);
            var okResult = result.Result as OkObjectResult;
            //Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}
