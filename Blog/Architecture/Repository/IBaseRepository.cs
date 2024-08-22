namespace Blog.Architecture.Repository
{
    public interface IBaseRepository<T>
    {
        T Obter(int id);
        IEnumerable<T> ObterTodos();

        long Incluir(T entity);
        bool Alterar(T entity);
        bool Excluir(T entity);

        Task<long> IncluirAsync(T entity);
        Task AlterarAsync(T entity);
        Task ExcluirAsync(T entity);
    }
}
