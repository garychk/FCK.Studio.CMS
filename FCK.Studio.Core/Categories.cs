using System;
using FCK.Studio.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FCK.Studio.Core
{
    [Table("Categories")]
    public class Categories : Entity<int>, IMustHaveTenant, ISoftDelete
    {
        [Required, MaxLength(50)]
        public virtual string CategoryName { get; set; }
        [Required, MaxLength(50)]
        public virtual string CategoryIndex { get; set; }
        [Required, MaxLength(50)]
        public virtual string Layout { get; set; }
        [Required]
        public virtual int ParentId { get; set; }
        [Required]
        public virtual int Childs { get; set; }
        [Required]
        public virtual int Level { get; set; }
        [Required]
        public bool IsHide { get; set; }
        public int TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
