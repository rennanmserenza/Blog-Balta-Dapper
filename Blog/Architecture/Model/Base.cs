namespace Blog.Architecture.Model
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Slug { get; set; } = string.Empty;
    }
}
