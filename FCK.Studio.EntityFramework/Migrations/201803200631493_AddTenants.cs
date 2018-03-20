namespace FCK.Studio.EntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTenants : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        TenantName = c.String(maxLength: 50),
                        SecretKey = c.Guid(nullable: false),
                        IsRoot = c.Boolean(nullable: false),
                        TenantConfig = c.String(storeType: "ntext"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tenants");
        }
    }
}
