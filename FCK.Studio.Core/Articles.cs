using System;
using FCK.Studio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

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
        public DateTime? UpdateTime { get; set; }
        [MaxLength(1000)]
        public string Intro { get; set; }
        [MaxLength(500)]
        public string Keywords { get; set; }
        [MaxLength(500)]
        public string Tags { get; set; }
        public string Images { get; set; }
        public int TenantId { get; set; }
        [Required, MaxLength(500)]
        public string Title { get; set; }
        public long? CreatorUserId { get; set; }
        [DefaultValue(0)]
        public int Hits { get; set; }
        public bool IsTop { get; set; }
        public bool IsHot { get; set; }
        public bool IsRecommend { get; set; }
        public bool IsChecked { get; set; }
        [MaxLength(50)]
        public string Author { get; set; }
        [MaxLength(200)]
        public string LinkUrl { get; set; }
        [MaxLength(200)]
        public string FileUrl { get; set; }
        public int CheckedLevel { get; set; }
        public Articles()
        {
            CreationTime = DateTime.Now;
        }
    }
}
