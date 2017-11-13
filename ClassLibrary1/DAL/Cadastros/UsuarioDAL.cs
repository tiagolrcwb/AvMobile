using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
namespace Persistencia.DAL.Cadastros
{
    public class UsuarioDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterUsuariosClassificadasPorId()
        {
            return context.Tbl_Usuario.Include(u => u.filial).Include(f => f.filial);
        }

        public Usuario ObterUsuarioPorId(long id)
        {
            return context.Tbl_Usuario.Where(u => u.id == id).First();
        }
        public void GravarUsuario(Usuario usuario)
        {
            if (usuario.id == null)
            {
                context.Tbl_Usuario.Add(usuario);
            }
            else
            {
                context.Entry(usuario).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

    }
}