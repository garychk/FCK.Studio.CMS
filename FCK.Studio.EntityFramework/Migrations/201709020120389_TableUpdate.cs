namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableUpdate : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Articles");
            DropPrimaryKey("dbo.Products");
            AlterColumn("dbo.Articles", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Articles", "Contents", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Articles", "Intro", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Articles", "Keywords", c => c.String(maxLength: 500));
            AlterColumn("dbo.Articles", "Tags", c => c.String(maxLength: 500));
            AlterColumn("dbo.Articles", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Categories", "CategoryName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "CategoryIndex", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Categories", "Layout", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Products", "Id", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Products", "Contents", c => c.String(unicode: false, storeType: "text"));
            AlterColumn("dbo.Products", "Intro", c => c.String(maxLength: 1000));
            AlterColumn("dbo.Products", "Keywords", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Tags", c => c.String(maxLength: 500));
            AlterColumn("dbo.Products", "Title", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, storeType: "money"));
            AddPrimaryKey("dbo.Articles", "Id");
            AddPrimaryKey("dbo.Products", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Products");
            DropPrimaryKey("dbo.Articles");
            AlterColumn("dbo.Products", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Products", "Title", c => c.String());
            AlterColumn("dbo.Products", "Tags", c => c.String());
            AlterColumn("dbo.Products", "Keywords", c => c.String());
            AlterColumn("dbo.Products", "Intro", c => c.String());
            AlterColumn("dbo.Products", "Contents", c => c.String());
            AlterColumn("dbo.Products", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Categories", "Layout", c => c.String());
            AlterColumn("dbo.Categories", "CategoryIndex", c => c.String());
            AlterColumn("dbo.Categories", "CategoryName", c => c.String());
            AlterColumn("dbo.Articles", "Title", c => c.String());
            AlterColumn("dbo.Articles", "Tags", c => c.String());
            AlterColumn("dbo.Articles", "Keywords", c => c.String());
            AlterColumn("dbo.Articles", "Intro", c => c.String());
            AlterColumn("dbo.Articles", "Contents", c => c.String());
            AlterColumn("dbo.Articles", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Products", "Id");
            AddPrimaryKey("dbo.Articles", "Id");
        }
    }
}
