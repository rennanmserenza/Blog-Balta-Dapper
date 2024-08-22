using System.ComponentModel.DataAnnotations.Schema;
using Blog.Architecture.Model;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category : BaseForm
    {
        public Category() => Posts = [];

        public List<Post> Posts { get; set; }
    }
}
