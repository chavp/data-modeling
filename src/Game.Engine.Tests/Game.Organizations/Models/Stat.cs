using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public class Stat : IdentityModel
    {
        public decimal? Level { get; set; }
        public decimal? HP { get; set; }
        public decimal? MP { get; set; }
        public decimal? Strength { get; set; }
        public decimal? Agility { get; set; }
        public decimal? Resilience { get; set; }
        public decimal? Experience { get; set; }

        public Guid PartyId { get; set; }
        public Party Party { get; set; }
    }
}
