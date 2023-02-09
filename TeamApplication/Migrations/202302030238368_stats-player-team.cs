namespace TeamApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statsplayerteam : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Stats", "PlayerID");
            CreateIndex("dbo.Stats", "TeamIDScoredAgainst");
            AddForeignKey("dbo.Stats", "PlayerID", "dbo.Players", "PlayerID", cascadeDelete: true);
            AddForeignKey("dbo.Stats", "TeamIDScoredAgainst", "dbo.Teams", "TeamID", cascadeDelete: true);
            DropColumn("dbo.Stats", "TeamIDPlayerTeam");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Stats", "TeamIDPlayerTeam", c => c.Int(nullable: false));
            DropForeignKey("dbo.Stats", "TeamIDScoredAgainst", "dbo.Teams");
            DropForeignKey("dbo.Stats", "PlayerID", "dbo.Players");
            DropIndex("dbo.Stats", new[] { "TeamIDScoredAgainst" });
            DropIndex("dbo.Stats", new[] { "PlayerID" });
        }
    }
}
