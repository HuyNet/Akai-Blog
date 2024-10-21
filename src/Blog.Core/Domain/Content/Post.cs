using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Core.Domain.Content
{
    [Table("Posts")]
    [Index(nameof(Slug),IsUnique = true)]
    public class Post
    {
        [Key]
        public Guid ObjectID { get; set; }
        [MaxLength(250)]
        public string? Name { get; set; }
        [Column(TypeName ="varchar(250)")]
        public string? Slug { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }
        public string? SeoDescription { get; set; }
        public string? Thumbnail { get; set; }
        public string? Content { get; set; }
        [MaxLength(250)]
        public string? Source { get; set; }
        public string? Tags { get; set; }
        public PostStatus Status { get; set; }

        public int ViewCount { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModifeid { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;

        public bool IsPaid { get; set; }
        public decimal RoyaltyAmount { get; set; }


        public Guid AuthorUserID { get; set; }
        [Required]
        public Guid CategoryPost { get; set; }

    }

    public enum PostStatus
    {
        Draft = 1,
        Canceled = 2,
        PendingForApproval =3,
        Rejected =4,
        PendingForPublish =5,
        published =6
    }
}
