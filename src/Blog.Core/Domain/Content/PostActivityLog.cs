using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domain.Content
{
    [Table("PostActivityLogs")]
    public class PostActivityLog
    {
        [Key]
        public Guid ObjectID { get; set; }
        [MaxLength(250)]
        public string? Note { get; set; }

        public PostStatus FromStatus {get;set;}
        public PostStatus ToStatus {get;set;}

        public DateTime DateCreated { get; set; }
        public DateTime? DateModifeid { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;
    }
}
