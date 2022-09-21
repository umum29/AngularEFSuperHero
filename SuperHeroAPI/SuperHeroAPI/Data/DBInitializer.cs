using System;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Data
{
    public static class DBInitializer
    {
        public static void Initialize(DataContext context)
        {
            // Look for any students.
            if (context.SuperHeroes.Any())
            {
                return;   // DB has been seeded
            }

            var heroes = new SuperHero[]
            {
                new SuperHero { Name = "SpiderMan", FirstName ="Peter", LastName = "Parker", Place="New York"},
                new SuperHero { Name = "IronMan", FirstName ="Tony", LastName = "Stark", Place="California"},
                new SuperHero { Name = "CapitainAmerica", FirstName ="Steve", LastName = "Keer", Place="New York"}
            };

            context.SuperHeroes.AddRange(heroes);
            context.SaveChanges();
        }
    }
}

