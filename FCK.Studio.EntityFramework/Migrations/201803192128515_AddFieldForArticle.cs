namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldForArticle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "Hits", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "IsTop", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "Author", c => c.String(maxLength: 50));
            AlterColumn("dbo.Articles", "UpdateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Articles", "UpdateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Articles", "Author");
            DropColumn("dbo.Articles", "IsTop");
            DropColumn("dbo.Articles", "Hits");
        }
    }
}
