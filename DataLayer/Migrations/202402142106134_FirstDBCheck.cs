namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDBCheck : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Borrows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        PeriodStartDate = c.DateTime(nullable: false),
                        PeriodFinishDate = c.DateTime(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .Index(t => t.MemberId)
                .Index(t => t.BookId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Auther = c.String(),
                        Barcode = c.String(),
                        Publisher = c.String(),
                        Piece = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BookMovements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                        MovementType = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                        MovementTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Books", t => t.BookId, cascadeDelete: true)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .ForeignKey("dbo.MovementTypes", t => t.MovementTypes_Id)
                .Index(t => t.MemberId)
                .Index(t => t.BookId)
                .Index(t => t.MovementTypes_Id);
            
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        RoleId = c.Int(nullable: false),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Penalties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MemberId = c.Int(nullable: false),
                        Detail = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId, cascadeDelete: true)
                .Index(t => t.MemberId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovementTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        CreateId = c.Int(nullable: false),
                        EditDate = c.DateTime(nullable: false),
                        EditId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrows", "BookId", "dbo.Books");
            DropForeignKey("dbo.BookMovements", "MovementTypes_Id", "dbo.MovementTypes");
            DropForeignKey("dbo.Members", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Penalties", "MemberId", "dbo.Members");
            DropForeignKey("dbo.Borrows", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BookMovements", "MemberId", "dbo.Members");
            DropForeignKey("dbo.BookMovements", "BookId", "dbo.Books");
            DropIndex("dbo.Penalties", new[] { "MemberId" });
            DropIndex("dbo.Members", new[] { "RoleId" });
            DropIndex("dbo.BookMovements", new[] { "MovementTypes_Id" });
            DropIndex("dbo.BookMovements", new[] { "BookId" });
            DropIndex("dbo.BookMovements", new[] { "MemberId" });
            DropIndex("dbo.Borrows", new[] { "BookId" });
            DropIndex("dbo.Borrows", new[] { "MemberId" });
            DropTable("dbo.MovementTypes");
            DropTable("dbo.Roles");
            DropTable("dbo.Penalties");
            DropTable("dbo.Members");
            DropTable("dbo.BookMovements");
            DropTable("dbo.Books");
            DropTable("dbo.Borrows");
        }
    }
}
