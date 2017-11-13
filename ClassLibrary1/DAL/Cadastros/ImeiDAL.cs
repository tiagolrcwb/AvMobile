using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
namespace Persistencia.DAL.Cadastros
{
    public class ImeiDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterImeiClassificadasPorId()
        {
            return context.Tbl_Imei.Include(i => i.aparelho).Include(a => a.aparelho).OrderBy(n => n.id);
        }

        public Imei ObterImeiPorId(long id)
        {
            return context.Tbl_Imei.Where(i => i.id == id).First();
        }
        public void GravarImei(Imei imei)
        {
            if (imei.id == null)
            {
                context.Tbl_Imei.Add(imei);
            }
            else
            {
                context.Entry(imei).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

    }
}
