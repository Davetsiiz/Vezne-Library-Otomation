namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class autRefactoring2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Roles", "MemberId", "dbo.Members");
            DropIndex("dbo.Roles", new[] { "MemberId" });
            AddColumn("dbo.Members", "RoleId", c => c.Int(nullable: false));
            CreateIndex("dbo.Members", "RoleId");
            AddForeignKey("dbo.Members", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
            DropColumn("dbo.Roles", "MemberId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Roles", "MemberId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Members", "RoleId", "dbo.Roles");
            DropIndex("dbo.Members", new[] { "RoleId" });
            DropColumn("dbo.Members", "RoleId");
            CreateIndex("dbo.Roles", "MemberId");
            AddForeignKey("dbo.Roles", "MemberId", "dbo.Members", "Id", cascadeDelete: true);
        }
    }
}
