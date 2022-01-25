namespace BoardGameInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDataLayer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.W40kArmy", "ArmyName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.W40kArmy", "ArmyName", c => c.String());
        }
    }
}
