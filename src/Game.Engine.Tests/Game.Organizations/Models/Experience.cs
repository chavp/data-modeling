using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public class Experience : IdentityModel
    {
        public Guid PartyId { get; set; }
        public Party Party { get; set; }

        public List<ExperienceItem> ExperienceItems { get; } = new();
    }
}
