using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.Contexts;
using System.Linq;
namespace Persistencia.DAL.Tabelas
{
    public class EstadoDAL
    {
        private EFContext context = new EFContext();
        public IQueryable<Estado> ObterEstadosClassificadosPorNome() { return context.Tbl_Estado.OrderBy(b => b.nome); }
    }
}