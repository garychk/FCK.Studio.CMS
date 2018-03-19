namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldForArticle1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Members",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        NickName = c.String(),
                        Photo = c.String(),
                        Email = c.String(nullable: false),
                        Country = c.String(maxLength: 20),
                        City = c.String(maxLength: 20),
                        Address = c.String(maxLength: 20),
                        Mobile = c.String(),
                        QQ = c.String(),
                        QQOpenID = c.String(),
                        WXOpenID = c.String(),
                        Points = c.Int(nullable: false),
                        Approved = c.Boolean(nullable: false),
                        Intro = c.String(maxLength: 500),
                        PoliticalRole = c.String(),
                        CreationTime = c.DateTime(nullable: false),
                        TenantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Articles", "Images", c => c.String());
            AddColumn("dbo.Articles", "IsSignUp", c => c.Boolean(nullable: false));
            AddColumn("dbo.Articles", "Enrolment", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "Enrolment");
            DropColumn("dbo.Articles", "IsSignUp");
            DropColumn("dbo.Articles", "Images");
            DropTable("dbo.Members");
        }
    }
}
