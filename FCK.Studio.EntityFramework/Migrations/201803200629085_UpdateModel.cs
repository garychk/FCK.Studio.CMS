namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "IsHot", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "IsRecommend", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "IsChecked", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "LinkUrl", c => c.String(maxLength: 200));
            AddColumn("dbo.Articles", "FileUrl", c => c.String(maxLength: 200));
            AddColumn("dbo.Articles", "CheckedLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Articles", "IsSignUp");
            DropColumn("dbo.Articles", "Enrolment");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Articles", "Enrolment", c => c.Int(nullable: false));
            AddColumn("dbo.Articles", "IsSignUp", c => c.Boolean(nullable: false));
            DropColumn("dbo.Articles", "CheckedLevel");
            DropColumn("dbo.Articles", "FileUrl");
            DropColumn("dbo.Articles", "LinkUrl");
            DropColumn("dbo.Articles", "IsChecked");
            DropColumn("dbo.Articles", "IsRecommend");
            DropColumn("dbo.Articles", "IsHot");
        }
    }
}
