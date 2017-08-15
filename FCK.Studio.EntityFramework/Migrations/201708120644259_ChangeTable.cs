namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                        CategoryIndex = c.String(),
                        Layout = c.String(),
                        ParentId = c.Int(nullable: false),
                        Childs = c.Int(nullable: false),
                        Level = c.Int(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("dbo.Articles", "CategoryId");
            AddForeignKey("dbo.Articles", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            DropColumn("dbo.Articles", "ClassId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "ClassId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropColumn("dbo.Articles", "CategoryId");
            DropTable("dbo.Categories");
        }
    }
}
