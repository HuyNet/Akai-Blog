using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domian.Content
{
    [Table("PostInSeries")]
    [PrimaryKey(nameof(PostID), nameof(SeriesID))]
    public class PostInSeries
    {
        public Guid PostID { get; set; }
        public Guid SeriesID { get; set; }
        public int DisplayOrder {  get; set; }
    }
}
