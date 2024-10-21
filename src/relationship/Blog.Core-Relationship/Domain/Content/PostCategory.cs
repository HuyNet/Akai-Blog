using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Core_Relationship.Domain.Content
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
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }

        [MaxLength(250)]
        public string? SeoDescription { get; set; }
        public Guid? ParentID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;

        public List<PostInTag> PostInTags { get; set; }
        public List<Post> Posts { get; set; } = new List<Post>();
        public List<PostInCategory> PostInCategories { get; set; }
    }

    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {

        }
    }
}
