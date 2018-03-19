namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldUpdateTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articles", "UpdateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Articles", "UpdateTime");
        }
    }
}
