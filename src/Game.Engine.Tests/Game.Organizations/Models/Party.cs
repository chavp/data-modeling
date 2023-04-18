using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public abstract class Party : IdentityModel
    {
        public string Name { get; set; }
    }
}
