using Blog.Core_Relationship.Domain.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core_Relationship.Domain.Content
{
    [Table("PostActivityLogs")]
    public class PostActivityLog
    {
        [Key]
        public Guid ObjectID { get; set; }

        [MaxLength(250)]
        public string? Note { get; set; }

        public PostStatus FromStatus { get; set; }
        public PostStatus ToStatus { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;
    }

    public class PostActivityLogConfiguration : IEntityTypeConfiguration<PostActivityLog>
    {
        public void Configure(EntityTypeBuilder<PostActivityLog> builder)
        {
            
        }
    }
}
