using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;
namespace Blog.Core_Relationship.Domain.Content
{
    [Table("PostInTags")]
    
    public class PostInTag
    {
        public Guid PostID { get; set; }
        public Guid TagID { get; set; }

        public Post Posts { get; set; }
        public Tag Tags { get; set; }
    }

    public class PostInTagConfiguration : IEntityTypeConfiguration<PostInTag>
    {
        public void Configure(EntityTypeBuilder<PostInTag> builder)
        {
            builder.HasKey(x => new { x.PostID, x.TagID });
            builder.HasOne(x=>x.Tags).WithMany(x=>x.PostInTags).HasForeignKey(x=>x.TagID);
            builder.HasOne(x=>x.Posts).WithMany(x=>x.PostInTags).HasForeignKey(x=>x.PostID);
        }
    }
}
