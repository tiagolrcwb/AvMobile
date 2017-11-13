using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;
namespace Servicos.Cadastros
{
    public class UsuarioServico
    {
        private UsuarioDAL usuarioDAL = new UsuarioDAL();
        public IQueryable ObterUsuariosClassificadasPorId()
        {
            return usuarioDAL.ObterUsuariosClassificadasPorId();
        }

        //Incluir filiais por cidade / estado

        public Usuario ObterUsuarioPorId(long id)
        {
            return usuarioDAL.ObterUsuarioPorId(id);
        }

        public void GravarUsuario(Usuario usuario)
        {
            usuarioDAL.GravarUsuario(usuario);
        }


    }
}