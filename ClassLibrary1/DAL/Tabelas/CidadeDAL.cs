using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Linq;
namespace Persistencia.DAL.Tabelas
{
    public class CidadeDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Cidade> ObterCidadesClassificadasPorNome() { return context.Tbl_Cidade.OrderBy(b => b.nome); }
    }
}