using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public class ExperienceItem : IdentityModel
    {
        public decimal Amount { get; set; }

        public Guid ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
