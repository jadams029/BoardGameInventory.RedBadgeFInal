namespace BoardGameInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignKeyWork : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Expansion", "Game_GameID", "dbo.BoardGame");
            DropIndex("dbo.Expansion", new[] { "Game_GameID" });
            RenameColumn(table: "dbo.Expansion", name: "Game_GameID", newName: "GameID");
            AlterColumn("dbo.Expansion", "GameID", c => c.Int(nullable: false));
            CreateIndex("dbo.Expansion", "GameID");
            AddForeignKey("dbo.Expansion", "GameID", "dbo.BoardGame", "GameID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expansion", "GameID", "dbo.BoardGame");
            DropIndex("dbo.Expansion", new[] { "GameID" });
            AlterColumn("dbo.Expansion", "GameID", c => c.Int());
            RenameColumn(table: "dbo.Expansion", name: "GameID", newName: "Game_GameID");
            CreateIndex("dbo.Expansion", "Game_GameID");
            AddForeignKey("dbo.Expansion", "Game_GameID", "dbo.BoardGame", "GameID");
        }
    }
}
