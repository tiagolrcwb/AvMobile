using Modelo.Cadastros;
using Modelo.Tabelas;
using Persistencia.DAL.Tabelas;
using System.Linq;
namespace Servicos.Tabelas
{
    public class CidadeServico
    {
        private CidadeDAL cidadeDAL = new CidadeDAL();
        public IQueryable<Cidade> ObterCidadesClassificadasPorNome() {
            return cidadeDAL.ObterCidadesClassificadasPorNome();
        }
    }
}