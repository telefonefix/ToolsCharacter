namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttributeFeatures",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pseudo = c.String(),
                        Gender = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                        IdCorporation = c.Int(),
                        IdGrade = c.Int(),
                        IdEthnic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Corporations", t => t.IdCorporation)
                .ForeignKey("dbo.Ethnics", t => t.IdEthnic, cascadeDelete: true)
                .ForeignKey("dbo.Grades", t => t.IdGrade)
                .Index(t => t.IdCorporation)
                .Index(t => t.IdGrade)
                .Index(t => t.IdEthnic);
            
            CreateTable(
                "dbo.AttributeResources",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Resources", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttributeSkills",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdFeature = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.IdFeature, cascadeDelete: true)
                .Index(t => t.IdFeature);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttributeSpecialAbilities",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Multiplier = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.SpecialAbilities", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SpecialAbilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Corporations",
                c => new
                    {
                        IdCorporation = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IsGang = c.Boolean(nullable: false),
                        Color = c.String(),
                    })
                .PrimaryKey(t => t.IdCorporation);
            
            CreateTable(
                "dbo.Ethnics",
                c => new
                    {
                        IdEthnic = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdEthnic);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Category = c.String(),
                        Quantity = c.Int(nullable: false),
                        Ressource = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeFeatures", "Id", "dbo.Features");
            DropForeignKey("dbo.AttributeFeatures", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.AttributeSpecialAbilities", "Id", "dbo.SpecialAbilities");
            DropForeignKey("dbo.AttributeSpecialAbilities", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeSkills", "Id", "dbo.Skills");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.AttributeSkills", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeResources", "Id", "dbo.Resources");
            DropForeignKey("dbo.AttributeResources", "Id", "dbo.Characters");
            DropIndex("dbo.AttributeSpecialAbilities", new[] { "Id" });
            DropIndex("dbo.AttributeSpecialAbilities", new[] { "IdCharactere" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.AttributeSkills", new[] { "Id" });
            DropIndex("dbo.AttributeSkills", new[] { "IdCharactere" });
            DropIndex("dbo.AttributeResources", new[] { "Id" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropIndex("dbo.AttributeFeatures", new[] { "Id" });
            DropIndex("dbo.AttributeFeatures", new[] { "IdCharactere" });
            DropTable("dbo.Grades");
            DropTable("dbo.Ethnics");
            DropTable("dbo.Corporations");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.AttributeSpecialAbilities");
            DropTable("dbo.Features");
            DropTable("dbo.Skills");
            DropTable("dbo.AttributeSkills");
            DropTable("dbo.Resources");
            DropTable("dbo.AttributeResources");
            DropTable("dbo.Characters");
            DropTable("dbo.AttributeFeatures");
        }
    }
}
