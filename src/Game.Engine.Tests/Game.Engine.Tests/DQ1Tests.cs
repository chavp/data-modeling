using Game.Organizations.Models.Mappings;
using Game.Organizations.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Game.Engine.Tests
{
    [TestClass]
    public class DQ1Tests
    {
        [TestMethod]
        public void TestPerson()
        {
            using var db = new OrganizationContext();

            var hero = new Person
            {
                Name = "Dai",
            };

            db.Parties.Add(hero);

            var initStat = new Stat
            {
                Level = 1,
                Experience = 0,
                Party = hero
            };
            db.Stats.Add(initStat);

            db.SaveChanges();
        }

        [TestMethod]
        public void TestPersonRead()
        {
            using var db = new OrganizationContext();
            using var tran = db.Database.BeginTransaction();

            var hero = db.Parties.OfType<Person>().Single(x => x.Name == "Dai");
            var stat = db.Stats.Single(x => x.Party == hero);

            var exp = new Experience
            {
                Party= hero,
            };
            db.Experiences.Add(exp);

            for (int i = 0; i < 1000; i++)
            {
                var expItem = new ExperienceItem
                {
                    Amount = i,
                    Experience = exp
                };

                exp.ExperienceItems.Add(expItem);
            }

            db.SaveChanges();
            tran.Commit();
        }

        [TestMethod]
        public void TestPersonUpdateStat()
        {
            // https://gamefaqs.gamespot.com/snes/564868-dragon-quest-i-and-ii/faqs/61640

            using var db = new OrganizationContext();
            var hero = db.Parties.OfType<Person>().Single(x => x.Name == "Dai");
            var stat = db.Stats.Single(x => x.Party == hero);
            var exp = db.Experiences.Include(x => x.ExperienceItems).Single(x => x.Party == hero);
            var totalExp = exp.ExperienceItems.Sum(x => x.Amount);

            stat.Experience = totalExp;
            stat.Level = getLevel((double)totalExp);
            stat.HP = 200;
            stat.Modified();


            // 7.805775683
            // 0.000378493203324836
            db.SaveChanges();
        }

        decimal getLevel(double x)
        {
            return (decimal)(7.805775683 + 0.000379 * x);
        }
    }
}
