using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;


namespace Blog.Core.Domian.Content
{
    [Table("PostTags")]
    [PrimaryKey(nameof(PostID),nameof(TagID))]
    public class PostTag
    {
        public Guid PostID { get; set; }
        public Guid TagID { get; set; }
    }
}
