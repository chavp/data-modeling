using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Person : Party
    {
        [StringLength(500)]
        public string Name { get; set; }
    }
}
