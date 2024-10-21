using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core_Relationship.Domain.Content
{
    public class PostInCategory
    {
        public Guid PostID { get; set; }
        public Guid CategoryID { get; set; }

        public Post Post { get; set; }
        public PostCategory PostCategory { get; set; }
    }

    public class PostInCategoryConfiguration : IEntityTypeConfiguration<PostInCategory>
    {
        public void Configure(EntityTypeBuilder<PostInCategory> builder)
        {
            builder.HasKey(x => new { x.PostID, x.CategoryID });
            builder.HasOne(x => x.Post).WithMany(p => p.PostInCategories).HasForeignKey(x => x.PostID).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.PostCategory).WithMany(pc => pc.PostInCategories).HasForeignKey(x => x.CategoryID).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
