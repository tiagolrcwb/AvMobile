using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;
namespace Servicos.Cadastros
{
    public class AparelhoServico
    {
        private AparelhoDAL aparelhoDAL = new AparelhoDAL();
        public IQueryable ObterAparelhosClassificadosPorNome()
        {
            return aparelhoDAL.ObterAparelhosClassificadosPorNome();
        }
        public Aparelho ObterAparelhoPorId(long id) {
            return aparelhoDAL.ObterAparelhoPorId(id);
        }
        public void GravarAparelho(Aparelho aparelho) {
            aparelhoDAL.GravarAparelho(aparelho);
        }
       

    }
}