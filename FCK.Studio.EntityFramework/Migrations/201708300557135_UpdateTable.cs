namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "CreatorUserId", c => c.Long());
            AddColumn("dbo.Categories", "IsHide", c => c.Boolean(nullable: false));
            AddColumn("dbo.Categories", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "CreatorUserId", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CreatorUserId");
            DropColumn("dbo.Categories", "IsDeleted");
            DropColumn("dbo.Categories", "IsHide");
            DropColumn("dbo.Articles", "CreatorUserId");
        }
    }
}
