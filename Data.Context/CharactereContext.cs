using Data.Entities.Attribute;
using Data.Entities.Characterize;
using Data.Entities.Corporation;
using Data.Entities.Person;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Data.Context
{
    public class CharactereContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Resource> Ressources { get; set; }
        public DbSet<Ethnic> Ethnics { get; set; }

        public DbSet<AttributeFeature> AttributeFeatures { get; set; }


        public CharactereContext() : base("CyberPunk3000")
        {
            // Important : Do not delete the below line
            SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
            .HasRequired<Ethnic>(s => s.Ethnic)
            .WithMany(g => g.Characters)
            .HasForeignKey<int>(s => s.IdEthnic);


            modelBuilder.Entity<AttributeFeature>().HasKey(q =>
            new {
                q.IdCharactere,
                q.IdFeature
            });

            // Relationships
            modelBuilder.Entity<AttributeFeature>()
                .HasRequired(t => t.Character)
                .WithMany(t => t.AttributeFeatures)
                .HasForeignKey(t => t.IdCharactere);

            modelBuilder.Entity<AttributeFeature>()
                .HasRequired(t => t.Feature)
                .WithMany(t => t.AttributeFeatures)
                .HasForeignKey(t => t.IdFeature);


            //modelBuilder.Entity<Character>()
            //    .HasMany<Feature>(f => f.Features)
            //    .WithMany(c => c.Characters)                
            //    .Map(cs =>
            //    {
            //        cs.MapLeftKey("CharacterRefId");
            //        cs.MapRightKey("FeatureRefId");
            //        cs.ToTable("AttributesFeatures");                    
            //    });
        }
    }
}
