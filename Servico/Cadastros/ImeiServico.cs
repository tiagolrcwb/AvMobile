using Modelo.Cadastros;
using Persistencia.DAL.Cadastros;
using System.Linq;
namespace Servicos.Cadastros
{
    public class ImeiServico
    {
        private ImeiDAL imeiDAL= new ImeiDAL();
        public IQueryable ObterImeiClassificadasPorId()
        {
            return imeiDAL.ObterImeiClassificadasPorId();
        }

        //Incluir filiais por cidade / estado

        public Imei ObterImeiPorId(long id)
        {
            return imeiDAL.ObterImeiPorId(id);
        }

        public void GravarImei(Imei imei)
        {
            imeiDAL.GravarImei(imei);
        }


    }
}