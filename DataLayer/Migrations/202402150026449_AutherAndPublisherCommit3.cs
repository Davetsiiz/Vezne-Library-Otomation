namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutherAndPublisherCommit3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Authers", "Name", c => c.String());
            AlterColumn("dbo.Publishers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Publishers", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Authers", "Name", c => c.Int(nullable: false));
        }
    }
}
