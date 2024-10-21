using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Core.Domian.Content
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public Guid ObjectID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime? DateModifeid { get; set; }
        public Guid UserCreated { get; set; }
        public Guid? UserModified { get; set; }
        public bool? IsDeleted { get; set; } = true;
    }
}
