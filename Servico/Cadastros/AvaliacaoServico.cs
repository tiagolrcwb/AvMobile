using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;
namespace Servicos.Cadastros
{
    public class AvaliacaoServico
    {
        private AvaliacaoDAL avaliacaoDAL = new AvaliacaoDAL();

        public IQueryable ObterAvaliacoesClassificadasPorId()
        {
            return avaliacaoDAL.ObterAvaliacoesClassificadasPorId();
        }

        public IQueryable ObterAvaliacoesAceitas()
        {
            return avaliacaoDAL.ObterAvaliacoesAceitas();
        }

        public IQueryable ObterAvaliacoesRecusadas()
        {
            return avaliacaoDAL.ObterAvaliacoesRecusadas();
        }

        public IQueryable ObterAvaliacoesAbertas()
        {
            return avaliacaoDAL.ObterAvaliacoesAbertas();
        }

        public Avaliacao ObterAvaliacaoPorId(long id)
        {
            return avaliacaoDAL.ObterAvaliacaoPorId(id);
        }

        public void GravarAvaliacao(Avaliacao avaliacao)
        {
            avaliacaoDAL.GravarAvaliacao(avaliacao);
        }


    }
}