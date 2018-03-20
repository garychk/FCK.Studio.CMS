using FCK.Studio.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Comments")]
    public class Comments : Entity<long>, IHasCreationTime, IMustHaveTenant
    {
        [MaxLength(20)]
        public string ModelName { get; set; }
        [Column(TypeName = "ntext")]
        public string Contents { get; set; }
        public DateTime CreationTime { get; set; }
        [ForeignKey("MemberId")]
        public virtual Members Member { get; set; }

        public int? MemberId { get; set; }

        public int TenantId { get; set; }
        public bool IsTop { get; set; }
        public bool IsRecommend { get; set; }
    }
}
