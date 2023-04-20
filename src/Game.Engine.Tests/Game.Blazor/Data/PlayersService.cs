using Game.Organizations.Models;
using Game.Organizations.Models.Mappings;
using Microsoft.EntityFrameworkCore;
using System;

namespace Game.Blazor.Data
{
    public class PlayersService
    {
        public Player AddPlayer(string name)
        {
            using var db = new OrganizationContext();

            var hero = db.Parties.OfType<Person>().SingleOrDefault(x => x.Name == name);
            if (hero == null)
            {
                hero = new Person
                {
                    Name = name,
                };
                db.Parties.Add(hero);

                var initStat = new Game.Organizations.Models.Stat
                {
                    Level = 1,
                    Experience = 0,
                    Party = hero
                };
                db.Stats.Add(initStat);

                db.SaveChanges();
            }

            var result = getPlayer(db, hero);

            return result;
        }

        public Player GetPlayerByName(string name)
        {
            using var db = new OrganizationContext();

            var hero = db.Parties.OfType<Person>().SingleOrDefault(x => x.Name == name);
            if (hero == null) return null;

            var result = getPlayer(db, hero);

            return result;
        }

        Player getPlayer(OrganizationContext db, Game.Organizations.Models.Person person)
        {
            var result = new Player { Id = person.Id, Name = person.Name };
            var stat = db.Stats.SingleOrDefault(x => x.Party == person);
            if (stat != null)
            {
                result.Stat = new Stat
                {
                    Level = stat.Level,
                    HP = stat.HP,
                    MP = stat.MP,
                    Agility = stat.Agility,
                    Experience = stat.Experience,
                    Resilience = stat.Resilience,
                    Strength = stat.Strength,
                };
            }

            return result;
        }

        public Player GetPlayerKillMonster(string name, double experience)
        {
            using var db = new OrganizationContext();

            var hero = db.Parties.OfType<Person>().SingleOrDefault(x => x.Name == name);
            if (hero == null) return null;

            var exp = db.Experiences.Include(x => x.ExperienceItems).SingleOrDefault(x => x.Party == hero);
            if(exp == null)
            {
                exp = new Experience
                {
                    Party = hero
                };
                db.Experiences.Add(exp);
            }
            exp.ExperienceItems.Add(new ExperienceItem { Experience = exp, Amount = experience });

            var stat = db.Stats.SingleOrDefault(x => x.Party == hero);
            if(stat != null)
            {
                stat.Experience = exp.ExperienceItems.Sum(x => x.Amount);
                stat.Level = getLevel(stat.Experience.GetValueOrDefault());
                stat.Modified();
            }

            db.SaveChanges();

            var result = getPlayer(db, hero);
            return result;
        }

        Dictionary<int, (int, int, int, int)> stats = new Dictionary<int, (int, int, int, int)>
        {
            { 1, (4,4,1,1) },

        };

        double getLevel(double x)
        {

            return Math.Floor(7.805775683 + 0.000379 * x);
        }
    }

    public class Player
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public Stat? Stat { get; set; }
    }

    public class Stat
    {
        public double? Level { get; set; }
        public double? HP { get; set; }
        public double? MP { get; set; }
        public double? Strength { get; set; }
        public double? Agility { get; set; }
        public double? Resilience { get; set; }
        public double? Experience { get; set; }
    }
}
