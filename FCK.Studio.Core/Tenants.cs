using FCK.Studio.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCK.Studio.Core
{
    [Table("Tenants")]
    public class Tenants : Entity<int>
    {
        [MaxLength(50)]
        public string TenantName { get; set; }
        [Column(TypeName = "uniqueidentifier")]
        public Guid SecretKey { get; set; }
        public bool IsRoot { get; set; }
        [Column(TypeName = "ntext")]
        public string TenantConfig { get; set; }
    }
}
