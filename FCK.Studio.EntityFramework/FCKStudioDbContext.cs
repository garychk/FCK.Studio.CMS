namespace FCK.Studio.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Core;

    public partial class FCKStudioDbContext : DbContext
    {
        public FCKStudioDbContext(string ConnStr = "FCKStudioDbContext")
            : base("name=" + ConnStr + "")
        {
        }
        public FCKStudioDbContext()
            : base("name=FCKStudioDbContext")
        {
        }
        public virtual IDbSet<Articles> Articles { get; set; }
        public virtual IDbSet<Products> Products { get; set; }
        public virtual IDbSet<Categories> Categories { get; set; }
        public virtual IDbSet<Admins> Admins { get; set; }
        public virtual IDbSet<Members> Members { get; set; }
        public virtual IDbSet<Tenants> Tenants { get; set; }
        public virtual IDbSet<Comments> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
