using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    public abstract class VersionModel
    {

        [StringLength(200)]
        public string CreatedBy { get; set; } = Environment.MachineName;

        public DateTime CreatedDate { get; protected set; } = DateTime.Now;

        [StringLength(200)]
        public string? ModifiedBy { get; protected set; }

        public DateTime? ModifiedDate { get; protected set; }

        public void Modified(string modifiedBy = null)
        {
            modifiedBy = modifiedBy ?? Environment.MachineName;
            ModifiedBy = Environment.MachineName;
        }
    }
}
