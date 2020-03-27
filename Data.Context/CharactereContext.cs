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
        public DbSet<Features> Features { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<ICorporation> Corporations { get; set; }
        public DbSet<Ressources> Ressources { get; set; }


        public CharactereContext() : base()
        {

        }
    }
}
