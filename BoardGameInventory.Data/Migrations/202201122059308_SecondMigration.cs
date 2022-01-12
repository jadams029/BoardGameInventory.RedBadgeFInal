namespace BoardGameInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardGame",
                c => new
                    {
                        GameID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        GameTitle = c.String(nullable: false),
                        Genre = c.Int(nullable: false),
                        NumberOfPlayers = c.Int(nullable: false),
                        TimeToPlayHours = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TimesPlayed = c.Int(nullable: false),
                        Expansions = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.GameID);
            
            CreateTable(
                "dbo.Expansion",
                c => new
                    {
                        ExpansionID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        ExpansionTitle = c.String(nullable: false),
                        ChangesToBase = c.String(nullable: false),
                        Game_GameID = c.Int(),
                    })
                .PrimaryKey(t => t.ExpansionID)
                .ForeignKey("dbo.BoardGame", t => t.Game_GameID)
                .Index(t => t.Game_GameID);
            
            CreateTable(
                "dbo.RPGBook",
                c => new
                    {
                        BookID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        BookTitle = c.String(nullable: false),
                        RPGSystem = c.String(nullable: false),
                        BookType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Expansion", "Game_GameID", "dbo.BoardGame");
            DropIndex("dbo.Expansion", new[] { "Game_GameID" });
            DropTable("dbo.RPGBook");
            DropTable("dbo.Expansion");
            DropTable("dbo.BoardGame");
        }
    }
}
