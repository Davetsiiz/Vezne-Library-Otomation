namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutherAndPublisherCommit2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Authers_Id", "dbo.Authers");
            DropForeignKey("dbo.Books", "Publishers_Id", "dbo.Publishers");
            DropIndex("dbo.Books", new[] { "Authers_Id" });
            DropIndex("dbo.Books", new[] { "Publishers_Id" });
            DropColumn("dbo.Books", "AutherId");
            DropColumn("dbo.Books", "PublisherId");
            RenameColumn(table: "dbo.Books", name: "Authers_Id", newName: "AutherId");
            RenameColumn(table: "dbo.Books", name: "Publishers_Id", newName: "PublisherId");
            AlterColumn("dbo.Books", "AutherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "AutherId", c => c.Int(nullable: false));
            AlterColumn("dbo.Books", "PublisherId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "AutherId");
            CreateIndex("dbo.Books", "PublisherId");
            AddForeignKey("dbo.Books", "AutherId", "dbo.Authers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "PublisherId", "dbo.Publishers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "PublisherId", "dbo.Publishers");
            DropForeignKey("dbo.Books", "AutherId", "dbo.Authers");
            DropIndex("dbo.Books", new[] { "PublisherId" });
            DropIndex("dbo.Books", new[] { "AutherId" });
            AlterColumn("dbo.Books", "PublisherId", c => c.Int());
            AlterColumn("dbo.Books", "AutherId", c => c.Int());
            AlterColumn("dbo.Books", "PublisherId", c => c.String());
            AlterColumn("dbo.Books", "AutherId", c => c.String());
            RenameColumn(table: "dbo.Books", name: "PublisherId", newName: "Publishers_Id");
            RenameColumn(table: "dbo.Books", name: "AutherId", newName: "Authers_Id");
            AddColumn("dbo.Books", "PublisherId", c => c.String());
            AddColumn("dbo.Books", "AutherId", c => c.String());
            CreateIndex("dbo.Books", "Publishers_Id");
            CreateIndex("dbo.Books", "Authers_Id");
            AddForeignKey("dbo.Books", "Publishers_Id", "dbo.Publishers", "Id");
            AddForeignKey("dbo.Books", "Authers_Id", "dbo.Authers", "Id");
        }
    }
}
