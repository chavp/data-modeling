using Game.Organizations.Models;
using Game.Organizations.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Tests
{
    // https://game.andaplus.com/web/index.php/th/162-walkthroughgame/dragon-quest-1-guides/5907-dragon-quest-1-by-arrpeegeez-com

    [TestClass]
    public class GamePartyTests
    {
        [TestMethod]
        public void TestPerson()
        {
            using var db = new OrganizationContext();

            var hero = new Team
            {
                Name = "Dai",
            };

            db.Parties.Add(hero);

            db.SaveChanges();
        }

        [TestMethod]
        public void TestPersonRead()
        {
            using var db = new OrganizationContext();

            var hero = db.Parties.OfType<Person>().Single(x => x.Name == "Dai");
            var stat = db.Stats.Single(x => x.Party == hero);

            hero.Name = "DaiDai";
            hero.Modified();
            db.SaveChanges();
        }
    }
}
