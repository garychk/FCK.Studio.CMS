using System;
using FCK.Studio.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    public class Articles : Entity<int>, IHasCreationTime, IMustHaveTenant, IStandardObjModel<int>
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

        public Articles()
        {
            CreationTime = DateTime.Now;
        }
    }
}
