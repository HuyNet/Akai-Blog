using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Core_Relationship.Domain.Content
{
    [Table("Series")]
    [Index(nameof(Slug), IsUnique = true)]
    public class Series
    {
        [Key]
        public Guid ObjectID { get; set; }
        public string? Name { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string? Slug { get; set; }

        [MaxLength(500)]
        public string? Description { get; set; }

        public string? SeoDescription { get; set; }
        public string? Thumbnail { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsActive { get; set; }
        public string? Content { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;

        public List<PostInSeries> PostInSeries { get; set; }
    }

    public class SeriesConfiguration : IEntityTypeConfiguration<Series>
    {
        public void Configure(EntityTypeBuilder<Series> builder)
        {

        }
    }
}
