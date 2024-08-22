using Blog.Architecture.Model;
using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")]
    public class User : BaseForm
    {
        public User() => Roles = [];

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;

        [Write(false)] // DAPPER NÃO SABE INCLUIR DEPENDENTES DE UMA CLASSE.
        public List<Role> Roles { get; set; }
    }
}
