namespace BoardGameInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _40KStuffAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.W40kArmy",
                c => new
                    {
                        ArmyID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        Army = c.Int(nullable: false),
                        ArmyName = c.String(),
                        ModelID = c.Int(nullable: false),
                        CodexAvailable = c.Boolean(nullable: false),
                        CodexOwned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ArmyID)
                .ForeignKey("dbo.W40kModel", t => t.ModelID, cascadeDelete: true)
                .Index(t => t.ModelID);
            
            CreateTable(
                "dbo.W40kModel",
                c => new
                    {
                        ModelID = c.Int(nullable: false, identity: true),
                        OnwerID = c.Guid(nullable: false),
                        ModelName = c.String(),
                        RoleSlot = c.Int(nullable: false),
                        MultipleLoadouts = c.Boolean(nullable: false),
                        PointsCosts = c.Int(nullable: false),
                        IsBuilt = c.Boolean(nullable: false),
                        IsPainted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ModelID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.W40kArmy", "ModelID", "dbo.W40kModel");
            DropIndex("dbo.W40kArmy", new[] { "ModelID" });
            DropTable("dbo.W40kModel");
            DropTable("dbo.W40kArmy");
        }
    }
}
