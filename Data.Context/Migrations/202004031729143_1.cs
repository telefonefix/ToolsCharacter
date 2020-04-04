namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttributeFeatures",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        IdFeature = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.IdFeature })
                .ForeignKey("dbo.Character", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.IdFeature, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.IdFeature);
            
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pseudo = c.String(),
                        Gender = c.Int(nullable: false),
                        IdEthnic = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                        Ethnic_IdEthnie = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ethnic", t => t.Ethnic_IdEthnie)
                .Index(t => t.Ethnic_IdEthnie);
            
            CreateTable(
                "dbo.Ethnic",
                c => new
                    {
                        IdEthnie = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdEthnie);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        IdFeatures = c.Int(nullable: false),
                        AcquiredPoint = c.Int(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Character", t => t.Character_Id)
                .Index(t => t.Character_Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Corporation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeFeatures", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.AttributeFeatures", "IdCharactere", "dbo.Character");
            DropForeignKey("dbo.SpecialAbilities", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Skills", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Resources", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Character", "Ethnic_IdEthnie", "dbo.Ethnic");
            DropIndex("dbo.SpecialAbilities", new[] { "Character_Id" });
            DropIndex("dbo.Skills", new[] { "Character_Id" });
            DropIndex("dbo.Resources", new[] { "Character_Id" });
            DropIndex("dbo.Character", new[] { "Ethnic_IdEthnie" });
            DropIndex("dbo.AttributeFeatures", new[] { "IdFeature" });
            DropIndex("dbo.AttributeFeatures", new[] { "IdCharactere" });
            DropTable("dbo.Corporation");
            DropTable("dbo.Features");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.Skills");
            DropTable("dbo.Resources");
            DropTable("dbo.Ethnic");
            DropTable("dbo.Character");
            DropTable("dbo.AttributeFeatures");
        }
    }
}
