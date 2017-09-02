using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCK.Studio.Entities
{
    public interface IStandardObjModel<CategoryPrimaryKey>
    {
        [Required, MaxLength(500)]
        string Title { get; set; }
        [Column(TypeName = "text")]
        string Contents { get; set; }
        string Keywords { get; set; }
        [MaxLength(1000)]
        string Intro { get; set; }
        [MaxLength(500)]
        string Tags { get; set; }
        CategoryPrimaryKey CategoryId { get; set; }
    }
}
