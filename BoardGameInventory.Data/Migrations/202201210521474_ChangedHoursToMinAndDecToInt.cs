namespace BoardGameInventory.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedHoursToMinAndDecToInt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardGame", "TimeToPlayMin", c => c.Int(nullable: false));
            DropColumn("dbo.BoardGame", "TimeToPlayHours");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BoardGame", "TimeToPlayHours", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.BoardGame", "TimeToPlayMin");
        }
    }
}
