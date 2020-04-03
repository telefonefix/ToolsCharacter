namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Character", "Ethnic_IdEthnie", c => c.Int());
            CreateIndex("dbo.Character", "Ethnic_IdEthnie");
            AddForeignKey("dbo.Character", "Ethnic_IdEthnie", "dbo.Ethnic", "IdEthnie");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Character", "Ethnic_IdEthnie", "dbo.Ethnic");
            DropIndex("dbo.Character", new[] { "Ethnic_IdEthnie" });
            DropColumn("dbo.Character", "Ethnic_IdEthnie");
        }
    }
}
