using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public abstract class EffectiveModel : IdentityModel
    {
        public DateTime? EffectiveFromDate { get; set; } = DateTime.Now.Date;
        public DateTime? EffectiveToDate { get; set; } = DateTime.MaxValue;

        public void Expired()
        {
            EffectiveToDate = DateTime.Today.AddSeconds(-1);
            Modified();
        }

        public void Expired(DateTime expiredDate)
        {
            EffectiveToDate = expiredDate;
            Modified();
        }
    }
}
