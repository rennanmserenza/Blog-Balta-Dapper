using Blog.Architecture.Model;
using System.Data.SqlClient;

namespace Blog.Architecture.Repository
{
    public class Repository<TModel>(SqlConnection connection) : BaseRepository<TModel>(connection) where TModel : Base
    {
        public new int Incluir(TModel model)
        {
            model.Id = 0;
            return (int)base.Incluir(model);
        }

        public new bool Alterar(TModel model)
        {
            if (model.Id != 0)
                return base.Alterar(model);

            return false;
        }

        public bool Excluir(int id)
        {
            if (id == 0)
                return false;

            var entidade = Obter(id);
            if (entidade is null)
                return false;

            return Excluir(entidade);
        }

        public new bool Excluir(TModel role)
        {
            return base.Excluir(role);
        }
    }
}
