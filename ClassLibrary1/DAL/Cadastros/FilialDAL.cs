using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
namespace Persistencia.DAL.Cadastros
{
    public class FilialDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterFiliaisClassificadasPorId()
        {
            return context.Tbl_Filial.Include(f => f.cidade).Include(c => c.cidade);
        }


        //Incluir filiais por cidade / estado


        public Filial ObterFilialPorId(long id)
        {
            return context.Tbl_Filial.Where(f => f.id == id).First();
        }
        public void GravarFilial(Filial filial)
        {
            if (filial.id == 0)
            {
                context.Tbl_Filial.Add(filial);
            }
            else
            {
                context.Entry(filial).State = EntityState.Modified;
            }
            context.SaveChanges();
        }

    }
}
