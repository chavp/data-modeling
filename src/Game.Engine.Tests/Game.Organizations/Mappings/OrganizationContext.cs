using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Game.Organizations.Models.Mappings
{
    public class OrganizationContext : DbContext
    {
        public DbSet<Party> Parties { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public string DbPath { get; }

        public OrganizationContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "organization.db");

            Database.Migrate();

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("organization");

            modelBuilder.Entity<Party>()
                .HasDiscriminator<string>("PartyType")
                .HasValue<Person>("Person")
                .HasValue<Team>("Team")
                ;

            base.OnModelCreating(modelBuilder);
        }

        // The following configures EF to create a Sqlite database file in the
        // special "local" folder for your platform.
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
