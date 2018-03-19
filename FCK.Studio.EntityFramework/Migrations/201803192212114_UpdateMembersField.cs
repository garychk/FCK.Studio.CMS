namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembersField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Members", "UserName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Members", "NickName", c => c.String(maxLength: 20));
            AlterColumn("dbo.Members", "Address", c => c.String(maxLength: 100));
            AlterColumn("dbo.Members", "Mobile", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "QQ", c => c.String(maxLength: 20));
            AlterColumn("dbo.Members", "QQOpenID", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "WXOpenID", c => c.String(maxLength: 50));
            AlterColumn("dbo.Members", "PoliticalRole", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Members", "PoliticalRole", c => c.String());
            AlterColumn("dbo.Members", "WXOpenID", c => c.String());
            AlterColumn("dbo.Members", "QQOpenID", c => c.String());
            AlterColumn("dbo.Members", "QQ", c => c.String());
            AlterColumn("dbo.Members", "Mobile", c => c.String());
            AlterColumn("dbo.Members", "Address", c => c.String(maxLength: 20));
            AlterColumn("dbo.Members", "NickName", c => c.String());
            AlterColumn("dbo.Members", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "UserName", c => c.String(nullable: false));
        }
    }
}
