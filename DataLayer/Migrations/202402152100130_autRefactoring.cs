namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autRefactoring : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "MemberId", c => c.Int(nullable: false));
            CreateIndex("dbo.Roles", "MemberId");
            AddForeignKey("dbo.Roles", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
            DropColumn("dbo.Members", "Role");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "Role", c => c.Int(nullable: false));
            DropForeignKey("dbo.Roles", "MemberId", "dbo.Members");
            DropIndex("dbo.Roles", new[] { "MemberId" });
            DropColumn("dbo.Roles", "MemberId");
        }
    }
}
