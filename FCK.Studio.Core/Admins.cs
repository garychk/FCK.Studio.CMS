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
    [Table("Admins")]
    public class Admins : Entity<int>, IHasCreationTime
    {
        [Required, MaxLength(50)]
        public string LoginName { get; set; }
        [Required, MaxLength(50)]
        public string Password { get; set; }
        [Required]
        public string Powers { get; set; }
        public DateTime CreationTime { get; set; }
        public Admins()
        {
            CreationTime = DateTime.Now;
        }
    }
}
