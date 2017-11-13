using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;
namespace Servicos.Tabelas
{
    public class EstadoServico
    {
        private EstadoDAL estadoDAL= new EstadoDAL();
        public IQueryable<Estado> ObterEstadosClassificadasPorNome()
        {
            return estadoDAL.ObterEstadosClassificadosPorNome();
        }
    }
}