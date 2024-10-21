using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Core.Domian.Content
{
    [Table("PostCategories")]
    [Index(nameof(Slug), IsUnique = true)]
    public class PostCategory
    {
        [Key]
        public Guid ObjectID { get; set; }
        [MaxLength(250)]
        public string? Name { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string? Slug { get; set; }
        public bool? IsActive {  get; set; }
        public int? SortOrder { get; set; }
        [MaxLength(250)]
        public string? SeoDescription { get; set; }
        public Guid? ParentID { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModifeid { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;

    }
}
