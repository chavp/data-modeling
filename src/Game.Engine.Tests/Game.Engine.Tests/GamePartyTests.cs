using Game.Organizations.Models;
using Game.Organizations.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Tests
{
    [TestClass]
    public class GamePartyTests
    {
        [TestMethod]
        public void TestPerson()
        {
            using var db = new OrganizationContext();

            var hero = new Person
            {
                Name = "Dai",
            };

            db.People.Add(hero);

            db.SaveChanges();
        }
    }
}
