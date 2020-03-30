using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Person;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class CharactereContext : DbContext
    {
        public DbSet<ICharacter> Characters { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ICorporation> Corporations { get; set; }
        public DbSet<Resource> Ressources { get; set; }


        public CharactereContext() : base("CyberPunk3000")
        {
            Database.SetInitializer<CharactereContext>(new CreateDatabaseIfNotExists<CharactereContext>());
        }
    }
}
