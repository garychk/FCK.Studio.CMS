using System;
using FCK.Studio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FCK.Studio.Core
{
    [Table("Articles")]
    public class Articles : Entity<long>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>, ICreationAudited
    {
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }
        [Column(TypeName = "text")]
        public string Contents { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        [MaxLength(1000)]
        public string Intro { get; set; }
        [MaxLength(500)]
        public string Keywords { get; set; }
        [MaxLength(500)]
        public string Tags { get; set; }

        public int TenantId { get; set; }
        [Required, MaxLength(500)]
        public string Title { get; set; }

        public long? CreatorUserId { get; set; }

        public Articles()
        {
            CreationTime = DateTime.Now;
        }
    }
}
