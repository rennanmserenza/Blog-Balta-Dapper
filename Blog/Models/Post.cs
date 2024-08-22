using Blog.Architecture.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog.Models
{
    [Table("[Post}")]
    public class Post : Base
    {
        public Post() => Tags = [];

        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public DateTime LastUpdateDate { get; set; } = DateTime.Now;

        public List<Tag> Tags { get; set; }
    }
}
