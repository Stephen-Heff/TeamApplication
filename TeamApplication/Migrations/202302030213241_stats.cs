namespace TeamApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stats : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        StatID = c.Int(nullable: false, identity: true),
                        PlayerID = c.Int(nullable: false),
                        TeamIDPlayerTeam = c.Int(nullable: false),
                        TeamIDScoredAgainst = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Stats");
        }
    }
}
