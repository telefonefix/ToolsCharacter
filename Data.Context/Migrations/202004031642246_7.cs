namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AttributeFeatures", "Character_Id", "dbo.Character");
            DropForeignKey("dbo.AttributeFeatures", "Feature_Id", "dbo.Features");
            DropIndex("dbo.AttributeFeatures", new[] { "Character_Id" });
            DropIndex("dbo.AttributeFeatures", new[] { "Feature_Id" });
            DropColumn("dbo.AttributeFeatures", "IdCharactere");
            DropColumn("dbo.AttributeFeatures", "IdFeature");
            RenameColumn(table: "dbo.AttributeFeatures", name: "Character_Id", newName: "IdCharactere");
            RenameColumn(table: "dbo.AttributeFeatures", name: "Feature_Id", newName: "IdFeature");
            DropPrimaryKey("dbo.AttributeFeatures");
            AlterColumn("dbo.AttributeFeatures", "IdCharactere", c => c.Int(nullable: false));
            AlterColumn("dbo.AttributeFeatures", "IdFeature", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AttributeFeatures", new[] { "IdCharactere", "IdFeature" });
            CreateIndex("dbo.AttributeFeatures", "IdCharactere");
            CreateIndex("dbo.AttributeFeatures", "IdFeature");
            AddForeignKey("dbo.AttributeFeatures", "IdCharactere", "dbo.Character", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AttributeFeatures", "IdFeature", "dbo.Features", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeFeatures", "IdFeature", "dbo.Features");
            DropForeignKey("dbo.AttributeFeatures", "IdCharactere", "dbo.Character");
            DropIndex("dbo.AttributeFeatures", new[] { "IdFeature" });
            DropIndex("dbo.AttributeFeatures", new[] { "IdCharactere" });
            DropPrimaryKey("dbo.AttributeFeatures");
            AlterColumn("dbo.AttributeFeatures", "IdFeature", c => c.Int());
            AlterColumn("dbo.AttributeFeatures", "IdCharactere", c => c.Int());
            AddPrimaryKey("dbo.AttributeFeatures", new[] { "IdCharactere", "IdFeature" });
            RenameColumn(table: "dbo.AttributeFeatures", name: "IdFeature", newName: "Feature_Id");
            RenameColumn(table: "dbo.AttributeFeatures", name: "IdCharactere", newName: "Character_Id");
            AddColumn("dbo.AttributeFeatures", "IdFeature", c => c.Int(nullable: false));
            AddColumn("dbo.AttributeFeatures", "IdCharactere", c => c.Int(nullable: false));
            CreateIndex("dbo.AttributeFeatures", "Feature_Id");
            CreateIndex("dbo.AttributeFeatures", "Character_Id");
            AddForeignKey("dbo.AttributeFeatures", "Feature_Id", "dbo.Features", "Id");
            AddForeignKey("dbo.AttributeFeatures", "Character_Id", "dbo.Character", "Id");
        }
    }
}
