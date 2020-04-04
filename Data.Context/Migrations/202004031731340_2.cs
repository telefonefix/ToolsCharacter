namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Character", "Ethnic_IdEthnie", "dbo.Ethnic");
            DropIndex("dbo.Character", new[] { "Ethnic_IdEthnie" });
            DropColumn("dbo.Character", "IdEthnic");
            RenameColumn(table: "dbo.Character", name: "Ethnic_IdEthnie", newName: "IdEthnic");
            AlterColumn("dbo.Character", "IdEthnic", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "IdEthnic");
            AddForeignKey("dbo.Character", "IdEthnic", "dbo.Ethnic", "IdEthnie", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "IdEthnic", "dbo.Ethnic");
            DropIndex("dbo.Character", new[] { "IdEthnic" });
            AlterColumn("dbo.Character", "IdEthnic", c => c.Int());
            RenameColumn(table: "dbo.Character", name: "IdEthnic", newName: "Ethnic_IdEthnie");
            AddColumn("dbo.Character", "IdEthnic", c => c.Int(nullable: false));
            CreateIndex("dbo.Character", "Ethnic_IdEthnie");
            AddForeignKey("dbo.Character", "Ethnic_IdEthnie", "dbo.Ethnic", "IdEthnie");
        }
    }
}
