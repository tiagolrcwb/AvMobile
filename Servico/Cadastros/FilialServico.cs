using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;
namespace Servicos.Cadastros
{
    public class FilialServico
    {
        private FilialDAL filialDAL = new FilialDAL();
        public IQueryable ObterFiliaisClassificadasPorId()
        {
            return filialDAL.ObterFiliaisClassificadasPorId();
        }
        
        //Incluir filiais por cidade / estado

        public Filial ObterFilialPorId(long id)
        {
            return filialDAL.ObterFilialPorId(id);
        }

        public void GravarFilial(Filial filial)
        {
            filialDAL.GravarFilial(filial);
        }


    }
}