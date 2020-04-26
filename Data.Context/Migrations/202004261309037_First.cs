namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Character", newName: "Characters");
            RenameTable(name: "dbo.Corporation", newName: "Corporations");
            DropForeignKey("dbo.Resources", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Skills", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.SpecialAbilities", "Character_Id", "dbo.Character");
            DropIndex("dbo.Resources", new[] { "Character_Id" });
            DropIndex("dbo.Skills", new[] { "Character_Id" });
            DropIndex("dbo.SpecialAbilities", new[] { "Character_Id" });
            DropPrimaryKey("dbo.Characters");
            CreateTable(
                "dbo.Areas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IdCity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cities", t => t.IdCity, cascadeDelete: true)
                .Index(t => t.IdCity);
            
            CreateTable(
                "dbo.AttributeKnowledgeAreas",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Areas", t => t.Id, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AttributeFeatures",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Features", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AttributeSkills",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AttributeSpecialAbilities",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.SpecialAbilities", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.AttributeProtections",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Protections", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Protections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AttributeResources",
                c => new
                    {
                        IdCharactere = c.Int(nullable: false),
                        Id = c.Int(nullable: false),
                        Value = c.Int(nullable: false),
                        Factor = c.Int(nullable: false),
                        Acquired = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.Id })
                .ForeignKey("dbo.Characters", t => t.IdCharactere, cascadeDelete: true)
                .ForeignKey("dbo.Corporations", t => t.Id, cascadeDelete: true)
                .Index(t => t.IdCharactere)
                .Index(t => t.Id);
            
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
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Characters", "IdCharactere", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Characters", "IdCorporation", c => c.Int());
            AddColumn("dbo.Characters", "IdGrade", c => c.Int());
            AddColumn("dbo.Characters", "IdEthnic", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Factor", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "IdFeature", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "IdSpecialAbility", c => c.Int());
            AddColumn("dbo.Skills", "SpecialAbility_Id", c => c.Int());
            AddColumn("dbo.Corporations", "IsGang", c => c.Boolean(nullable: false));
            AddColumn("dbo.Corporations", "Color", c => c.String());
            AddPrimaryKey("dbo.Characters", "IdCharactere");
            CreateIndex("dbo.Characters", "IdCorporation");
            CreateIndex("dbo.Characters", "IdGrade");
            CreateIndex("dbo.Characters", "IdEthnic");
            CreateIndex("dbo.Skills", "IdFeature");
            CreateIndex("dbo.Skills", "SpecialAbility_Id");
            AddForeignKey("dbo.Skills", "IdFeature", "dbo.Features", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Skills", "SpecialAbility_Id", "dbo.SpecialAbilities", "Id");
            AddForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations", "Id");
            AddForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics", "IdEthnic", cascadeDelete: true);
            AddForeignKey("dbo.Characters", "IdGrade", "dbo.Grades", "Id");
            DropColumn("dbo.Characters", "Id");
            DropColumn("dbo.Skills", "Value");
            DropColumn("dbo.Skills", "IdFeatures");
            DropColumn("dbo.Skills", "AcquiredPoint");
            DropColumn("dbo.Skills", "Character_Id");
            DropColumn("dbo.SpecialAbilities", "Value");
            DropColumn("dbo.SpecialAbilities", "Character_Id");
            DropColumn("dbo.Features", "Value");
            DropTable("dbo.Resources");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                        Character_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Features", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.SpecialAbilities", "Character_Id", c => c.Int());
            AddColumn("dbo.SpecialAbilities", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Character_Id", c => c.Int());
            AddColumn("dbo.Skills", "AcquiredPoint", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "IdFeatures", c => c.Int(nullable: false));
            AddColumn("dbo.Skills", "Value", c => c.Int(nullable: false));
            AddColumn("dbo.Characters", "Id", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Areas", "IdCity", "dbo.Cities");
            DropForeignKey("dbo.AttributeKnowledgeAreas", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.Characters", "IdGrade", "dbo.Grades");
            DropForeignKey("dbo.Characters", "IdEthnic", "dbo.Ethnics");
            DropForeignKey("dbo.Characters", "IdCorporation", "dbo.Corporations");
            DropForeignKey("dbo.AttributeResources", "Id", "dbo.Corporations");
            DropForeignKey("dbo.AttributeResources", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeProtections", "Id", "dbo.Protections");
            DropForeignKey("dbo.AttributeProtections", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeFeatures", "Id", "dbo.Features");
            DropForeignKey("dbo.Skills", "SpecialAbility_Id", "dbo.SpecialAbilities");
            DropForeignKey("dbo.AttributeSpecialAbilities", "Id", "dbo.SpecialAbilities");
            DropForeignKey("dbo.AttributeSpecialAbilities", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.Skills", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.AttributeSkills", "Id", "dbo.Skills");
            DropForeignKey("dbo.AttributeSkills", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeFeatures", "IdCharactere", "dbo.Characters");
            DropForeignKey("dbo.AttributeKnowledgeAreas", "Id", "dbo.Areas");
            DropIndex("dbo.AttributeResources", new[] { "Id" });
            DropIndex("dbo.AttributeResources", new[] { "IdCharactere" });
            DropIndex("dbo.AttributeProtections", new[] { "Id" });
            DropIndex("dbo.AttributeProtections", new[] { "IdCharactere" });
            DropIndex("dbo.AttributeSpecialAbilities", new[] { "Id" });
            DropIndex("dbo.AttributeSpecialAbilities", new[] { "IdCharactere" });
            DropIndex("dbo.AttributeSkills", new[] { "Id" });
            DropIndex("dbo.AttributeSkills", new[] { "IdCharactere" });
            DropIndex("dbo.Skills", new[] { "SpecialAbility_Id" });
            DropIndex("dbo.Skills", new[] { "IdFeature" });
            DropIndex("dbo.AttributeFeatures", new[] { "Id" });
            DropIndex("dbo.AttributeFeatures", new[] { "IdCharactere" });
            DropIndex("dbo.Characters", new[] { "IdEthnic" });
            DropIndex("dbo.Characters", new[] { "IdGrade" });
            DropIndex("dbo.Characters", new[] { "IdCorporation" });
            DropIndex("dbo.AttributeKnowledgeAreas", new[] { "Id" });
            DropIndex("dbo.AttributeKnowledgeAreas", new[] { "IdCharactere" });
            DropIndex("dbo.Areas", new[] { "IdCity" });
            DropPrimaryKey("dbo.Characters");
            DropColumn("dbo.Corporations", "Color");
            DropColumn("dbo.Corporations", "IsGang");
            DropColumn("dbo.Skills", "SpecialAbility_Id");
            DropColumn("dbo.Skills", "IdSpecialAbility");
            DropColumn("dbo.Skills", "IdFeature");
            DropColumn("dbo.Skills", "Factor");
            DropColumn("dbo.Characters", "IdEthnic");
            DropColumn("dbo.Characters", "IdGrade");
            DropColumn("dbo.Characters", "IdCorporation");
            DropColumn("dbo.Characters", "IdCharactere");
            DropTable("dbo.Cities");
            DropTable("dbo.Grades");
            DropTable("dbo.Ethnics");
            DropTable("dbo.AttributeResources");
            DropTable("dbo.Protections");
            DropTable("dbo.AttributeProtections");
            DropTable("dbo.AttributeSpecialAbilities");
            DropTable("dbo.AttributeSkills");
            DropTable("dbo.AttributeFeatures");
            DropTable("dbo.AttributeKnowledgeAreas");
            DropTable("dbo.Areas");
            AddPrimaryKey("dbo.Characters", "Id");
            CreateIndex("dbo.SpecialAbilities", "Character_Id");
            CreateIndex("dbo.Skills", "Character_Id");
            CreateIndex("dbo.Resources", "Character_Id");
            AddForeignKey("dbo.SpecialAbilities", "Character_Id", "dbo.Character", "Id");
            AddForeignKey("dbo.Skills", "Character_Id", "dbo.Character", "Id");
            AddForeignKey("dbo.Resources", "Character_Id", "dbo.Character", "Id");
            RenameTable(name: "dbo.Corporations", newName: "Corporation");
            RenameTable(name: "dbo.Characters", newName: "Character");
        }
    }
}
