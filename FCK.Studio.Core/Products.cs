using FCK.Studio.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Products")]
    public class Products : Entity<long>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>, ICreationAudited
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
        public string Picture { get; set; }
        public string Pictures { get; set; }
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public long? CreatorUserId { get; set; }
        public Products()
        {
            CreationTime = DateTime.Now;
        }
    }
}
