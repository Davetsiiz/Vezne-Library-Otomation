namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RoleCheck2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Members", "RoleId", "dbo.Roles");
            DropIndex("dbo.Members", new[] { "RoleId" });
            AddColumn("dbo.Borrows", "ReturnedDate", c => c.DateTime());
            AddColumn("dbo.Members", "Role", c => c.Int(nullable: false));
            DropColumn("dbo.Members", "RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Members", "RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Members", "Role");
            DropColumn("dbo.Borrows", "ReturnedDate");
            CreateIndex("dbo.Members", "RoleId");
            AddForeignKey("dbo.Members", "RoleId", "dbo.Roles", "Id", cascadeDelete: true);
        }
    }
}
