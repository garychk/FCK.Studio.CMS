namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddComment : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Tenants");
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ModelName = c.String(maxLength: 20),
                        Contents = c.String(storeType: "ntext"),
                        CreationTime = c.DateTime(nullable: false),
                        MemberId = c.Int(),
                        TenantId = c.Int(nullable: false),
                        IsTop = c.Boolean(nullable: false),
                        IsRecommend = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Members", t => t.MemberId)
                .Index(t => t.MemberId);
            
            AlterColumn("dbo.Tenants", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Tenants", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "MemberId", "dbo.Members");
            DropIndex("dbo.Comments", new[] { "MemberId" });
            DropPrimaryKey("dbo.Tenants");
            AlterColumn("dbo.Tenants", "Id", c => c.Long(nullable: false, identity: true));
            DropTable("dbo.Comments");
            AddPrimaryKey("dbo.Tenants", "Id");
        }
    }
}
