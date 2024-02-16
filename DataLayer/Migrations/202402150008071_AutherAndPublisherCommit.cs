namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AutherAndPublisherCommit : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Publishers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "AutherId", c => c.String());
            AddColumn("dbo.Books", "PublisherId", c => c.String());
            AddColumn("dbo.Books", "Authers_Id", c => c.Int());
            AddColumn("dbo.Books", "Publishers_Id", c => c.Int());
            CreateIndex("dbo.Books", "Authers_Id");
            CreateIndex("dbo.Books", "Publishers_Id");
            AddForeignKey("dbo.Books", "Authers_Id", "dbo.Authers", "Id");
            AddForeignKey("dbo.Books", "Publishers_Id", "dbo.Publishers", "Id");
            DropColumn("dbo.Books", "Auther");
            DropColumn("dbo.Books", "Publisher");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Publisher", c => c.String());
            AddColumn("dbo.Books", "Auther", c => c.String());
            DropForeignKey("dbo.Books", "Publishers_Id", "dbo.Publishers");
            DropForeignKey("dbo.Books", "Authers_Id", "dbo.Authers");
            DropIndex("dbo.Books", new[] { "Publishers_Id" });
            DropIndex("dbo.Books", new[] { "Authers_Id" });
            DropColumn("dbo.Books", "Publishers_Id");
            DropColumn("dbo.Books", "Authers_Id");
            DropColumn("dbo.Books", "PublisherId");
            DropColumn("dbo.Books", "AutherId");
            DropTable("dbo.Publishers");
            DropTable("dbo.Authers");
        }
    }
}
