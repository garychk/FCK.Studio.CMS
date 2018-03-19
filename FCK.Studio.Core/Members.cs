using FCK.Studio.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Core
{
    [Table("Members")]
    public class Members : Entity<int>, IHasCreationTime, IMustHaveTenant
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(20)]
        public string NickName { get; set; }
        public string Photo { get; set; }
        [Required]
        public string Email { get; set; }
        [MaxLength(20)]
        public string Country { get; set; }
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }
        [MaxLength(50)]
        public string Mobile { get; set; }
        [MaxLength(20)]
        public string QQ { get; set; }
        [MaxLength(50)]
        public string QQOpenID { get; set; }
        [MaxLength(50)]
        public string WXOpenID { get; set; }
        [DefaultValue(0)]
        public int Points { get; set; }
        public bool Approved { get; set; }
        [MaxLength(500)]
        public string Intro { get; set; }
        [MaxLength(20)]
        public string PoliticalRole { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        [Required]
        public int TenantId { get; set; }
    }
}
