using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public class Stat : IdentityModel
    {
        public double? Level { get; set; }
        public double? HP { get; set; }
        public double? MP { get; set; }
        public double? Strength { get; set; }
        public double? Agility { get; set; }
        public double? Resilience { get; set; }
        public double? Experience { get; set; }

        public Guid PartyId { get; set; }
        public Party Party { get; set; }
    }
}
