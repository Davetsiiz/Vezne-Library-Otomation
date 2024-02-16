namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Authers", newName: "Authors");
            RenameColumn(table: "dbo.Books", name: "AutherId", newName: "AuthorId");
            RenameIndex(table: "dbo.Books", name: "IX_AutherId", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_AutherId");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "AutherId");
            RenameTable(name: "dbo.Authors", newName: "Authers");
        }
    }
}
