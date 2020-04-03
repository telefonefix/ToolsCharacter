namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
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
                        Character_Id = c.Int(),
                        Feature_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.IdCharactere, t.IdFeature })
                .ForeignKey("dbo.Character", t => t.Character_Id)
                .ForeignKey("dbo.Features", t => t.Feature_Id)
                .Index(t => t.Character_Id)
                .Index(t => t.Feature_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeFeatures", "Feature_Id", "dbo.Features");
            DropForeignKey("dbo.AttributeFeatures", "Character_Id", "dbo.Character");
            DropIndex("dbo.AttributeFeatures", new[] { "Feature_Id" });
            DropIndex("dbo.AttributeFeatures", new[] { "Character_Id" });
            DropTable("dbo.AttributeFeatures");
        }
    }
}
