using Data.Entities.Attribute;
using Data.Entities.Characterize;
using Data.Entities.Enterprise;
using Data.Entities.Person;
using Data.Entities.Places;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Data.Context
{
    public class CharactereContext : DbContext
    {
        public DbSet<Character> Characters { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<SpecialAbility> SpecialAbilities { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Corporation> Corporations { get; set; }
        public DbSet<Grade> Grades { get; set; }        
        public DbSet<Ethnic> Ethnics { get; set; }
        public DbSet<Protection> Protections { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<City> Cities { get; set; }


        public DbSet<AttributeFeature> AttributeFeatures { get; set; }
        public DbSet<AttributeSkill> AttributeSkills { get; set; }
        public DbSet<AttributeSpecialAbility> AttributeSpecialAbilities { get; set; }
        public DbSet<AttributeProtection> AttributeProtections { get; set; }
        public DbSet<AttributeResource> AttributeResources { get; set; }
        public DbSet<AttributeKnowledgeArea> attributeKnowledgeAreas { get; set; }



        public CharactereContext() : base("CyberPunk3000")
        {
            // Important : Do not delete the below line
            SqlProviderServices ensureDLLIsCopied = SqlProviderServices.Instance;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Character>()
            .HasRequired<Ethnic>(c => c.Ethnic)
            .WithMany(e=> e.Characters)
            .HasForeignKey<int>(c => c.IdEthnic);


            modelBuilder.Entity<Character>()
                .HasOptional<ICorporation>(c=>c.Corporation)
                .WithMany(c=>c.Characters)
                .HasForeignKey<int?>(c => c.IdCorporation);

            modelBuilder.Entity<Character>()
                .HasOptional<IGrade>(c=> c.Grade)
                .WithMany(c => c.Characters)
                .HasForeignKey<int?>(c => c.IdGrade);

            modelBuilder.Entity<Skill>()
                .HasRequired<Feature>(s => s.Feature)
                .WithMany(s => s.Skills)
                .HasForeignKey<int>(s => s.IdFeature);

            modelBuilder.Entity<Area>()
                .HasRequired<City>(s => s.City)
                .WithMany(s => s.Areas)
                .HasForeignKey<int>(s => s.IdCity);

            modelBuilder.Entity<AttributeFeature>().HasKey(a =>
            new
            {
                a.IdCharactere,
                a.Id
            });

            modelBuilder.Entity<AttributeSpecialAbility>().HasKey(a =>
            new
            {
                a.IdCharactere,
                a.Id
            });

            modelBuilder.Entity<AttributeSkill>().HasKey(a =>
            new
            {
                a.IdCharactere,
                a.Id
            });

            modelBuilder.Entity<AttributeResource>().HasKey(a =>
            new
            {
                a.IdCharactere,
                a.Id
            });
            modelBuilder.Entity<AttributeKnowledgeArea>().HasKey(a =>
            new
            {
                a.IdCharactere,
                a.Id
            });
            //******************************************************************************************
            // Relationships 
            //-----------------------------------------------------------------
            //  between Characteres and Features
            modelBuilder.Entity<AttributeFeature>()
                .HasRequired(t => t.Character)
                .WithMany(t => t.AttributeFeatures)
                .HasForeignKey(t => t.IdCharactere);

            modelBuilder.Entity<AttributeFeature>()
                .HasRequired(t => t.Feature)
                .WithMany(t => t.AttributeFeatures)
                .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            //  between Characteres and SpecialAbilities
            modelBuilder.Entity<AttributeSpecialAbility>()
                .HasRequired(t => t.Character)
                .WithMany(t => t.AttributeSpecialAbilities)
                .HasForeignKey(t => t.IdCharactere);

            modelBuilder.Entity<AttributeSpecialAbility>()
                .HasRequired(t => t.SpecialAbility)
                .WithMany(t => t.AttributeSpecialAbility)
                .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //-----------------------------------------------------------------
            //  between Characteres and Skills
            modelBuilder.Entity<AttributeSkill>()
                .HasRequired(t => t.Character)
                .WithMany(t => t.AttributeSkills)
                .HasForeignKey(t => t.IdCharactere);

            modelBuilder.Entity<AttributeSkill>()
                .HasRequired(t => t.Skill)
                .WithMany(t => t.AttributeSkills)
                .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //  between Characteres and Areas
            modelBuilder.Entity<AttributeKnowledgeArea>()
                .HasRequired(t => t.Character)
                .WithMany(t => t.AttributeKnowledgeArea)
                .HasForeignKey(t => t.IdCharactere);

            modelBuilder.Entity<AttributeKnowledgeArea>()
                .HasRequired(t => t.Area)
                .WithMany(t => t.AttributeKnowledgeArea)
                .HasForeignKey(t => t.Id);
            //-----------------------------------------------------------------
            //******************************************************************************************

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
