using System;
using FCK.Studio.Entities;

namespace FCK.Studio.Core
{
    public class Categories : Entity<int>, IMustHaveTenant, ISoftDelete
    {
        public virtual string CategoryName { get; set; }
        public virtual string CategoryIndex { get; set; }
        public virtual string Layout { get; set; }
        public virtual int ParentId { get; set; }
        public virtual int Childs { get; set; }
        public virtual int Level { get; set; }
        public bool IsHide { get; set; }
        public int TenantId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
