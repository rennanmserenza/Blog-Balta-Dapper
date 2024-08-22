using System.ComponentModel.DataAnnotations.Schema;
using Blog.Architecture.Model;

namespace Blog.Models
{
    [Table("[Tag]")]
    public class Tag : BaseForm
    {
        public Tag() => Posts = [];

        public List<Post> Posts { get; set; }
    }
}
