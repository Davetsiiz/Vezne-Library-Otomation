namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Refactoring1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.MovementTypes", "CreateId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovementTypes", "CreateId", c => c.Int(nullable: false));
        }
    }
}
