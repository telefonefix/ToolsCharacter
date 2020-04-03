namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Character",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Pseudo = c.String(),
                        Gender = c.Int(nullable: false),
                        Chance = c.Int(nullable: false),
                        Alive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Corporation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SpecialAbilities", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Skills", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.Resources", "Character_Id", "dbo.Character");
            DropIndex("dbo.SpecialAbilities", new[] { "Character_Id" });
            DropIndex("dbo.Skills", new[] { "Character_Id" });
            DropIndex("dbo.Resources", new[] { "Character_Id" });
            DropTable("dbo.Features");
            DropTable("dbo.Corporation");
            DropTable("dbo.SpecialAbilities");
            DropTable("dbo.Skills");
            DropTable("dbo.Resources");
            DropTable("dbo.Character");
        }
    }
}
