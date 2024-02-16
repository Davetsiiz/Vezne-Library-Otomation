namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstDBCheck2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BookMovements", "MovementTypes_Id", "dbo.MovementTypes");
            DropIndex("dbo.BookMovements", new[] { "MovementTypes_Id" });
            RenameColumn(table: "dbo.BookMovements", name: "MovementTypes_Id", newName: "MovementTypeId");
            AlterColumn("dbo.BookMovements", "MovementTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.BookMovements", "MovementTypeId");
            AddForeignKey("dbo.BookMovements", "MovementTypeId", "dbo.MovementTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.BookMovements", "MovementType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BookMovements", "MovementType", c => c.Int(nullable: false));
            DropForeignKey("dbo.BookMovements", "MovementTypeId", "dbo.MovementTypes");
            DropIndex("dbo.BookMovements", new[] { "MovementTypeId" });
            AlterColumn("dbo.BookMovements", "MovementTypeId", c => c.Int());
            RenameColumn(table: "dbo.BookMovements", name: "MovementTypeId", newName: "MovementTypes_Id");
            CreateIndex("dbo.BookMovements", "MovementTypes_Id");
            AddForeignKey("dbo.BookMovements", "MovementTypes_Id", "dbo.MovementTypes", "Id");
        }
    }
}
