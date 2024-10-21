using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core_Relationship.Domain.Content
{
    [Table("PostInSeries")]
    [PrimaryKey(nameof(PostID), nameof(SeriesID))]
    public class PostInSeries
    {
        public Guid PostID { get; set; }
        public Guid SeriesID { get; set; }
        public int DisplayOrder { get; set; }

        public Post Posts { get; set;}
        public Series Series { get; set; }
    }

    public class PostInSeriesConfiguration : IEntityTypeConfiguration<PostInSeries>
    {
        public void Configure(EntityTypeBuilder<PostInSeries> builder)
        {
            builder.HasKey(x => new { x.PostID, x.SeriesID });
            builder.HasOne(x=>x.Posts).WithMany(x=>x.PostInSeries).HasForeignKey(x=>x.PostID);
            builder.HasOne(x=>x.Series).WithMany(x=>x.PostInSeries).HasForeignKey(x=>x.SeriesID);
        }
    }
}
