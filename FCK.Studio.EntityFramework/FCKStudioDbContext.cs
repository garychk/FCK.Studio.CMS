namespace FCK.Studio.EntityFramework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Core;

    public partial class FCKStudioDbContext : DbContext
    {
        public FCKStudioDbContext(string ConnStr)
            : base("name="+ ConnStr + "")
        {
        }
        public virtual IDbSet<Articles> Articles { get; set; }
        public virtual IDbSet<Products> Products { get; set; }
        public virtual IDbSet<Categories> Categories { get; set; }
        public virtual IDbSet<Admins> Admins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
