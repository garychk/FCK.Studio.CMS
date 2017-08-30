using FCK.Studio.Entities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    public class Products : Entity<int>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>, ICreationAudited
    {
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Categories Category { get; set; }

        public string Contents { get; set; }

        public DateTime CreationTime { get; set; }

        public string Intro { get; set; }

        public string Keywords { get; set; }

        public string Tags { get; set; }

        public int TenantId { get; set; }

        public string Title { get; set; }
        public string Picture { get; set; }
        public string Pictures { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

        public long? CreatorUserId { get; set; }
        public Products()
        {
            CreationTime = DateTime.Now;
        }
    }
}
