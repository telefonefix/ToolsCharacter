namespace Data.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ethnic",
                c => new
                    {
                        IdEthnie = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.IdEthnie);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Ethnic");
        }
    }
}
