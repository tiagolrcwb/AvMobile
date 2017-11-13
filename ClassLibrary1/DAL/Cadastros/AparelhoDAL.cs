using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
namespace Persistencia.DAL.Cadastros
{
    public class AparelhoDAL
    {
        private EFContext context = new EFContext();


        public IQueryable ObterAparelhosClassificadosPorNome()
        {
            return context.Tbl_Aparelho.OrderBy(a => a.modelo);
        }


        public Aparelho ObterAparelhoPorId(long id)
        {
            return context.Tbl_Aparelho.Where(a => a.id == id).First();
        }


        public void GravarAparelho(Aparelho aparelho)
        {
            int idAparelho = aparelho.id; 
            if (idAparelho == 0)//Perguntar para professor porque não pode comparar com NULL conforme o livro
            {
                context.Tbl_Aparelho.Add(aparelho);
            }
            else
            {
                context.Entry(aparelho).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
