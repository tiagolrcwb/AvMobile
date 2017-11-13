using Persistencia.Contexts;
using System.Linq;
using System.Data.Entity;
using Modelo.Cadastros;
namespace Persistencia.DAL.Cadastros
{
    public class AvaliacaoDAL
    {
        private EFContext context = new EFContext();

        public IQueryable ObterAvaliacoesClassificadasPorId()
        {
            return context.Tbl_Avaliacao.Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei);
        }
        public IQueryable ObterAvaliacoesAceitas()
        {
            return context.Tbl_Avaliacao.Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei).Where(a => a.aceite == 1);
        }
        public IQueryable ObterAvaliacoesAbertas()
        {
            return context.Tbl_Avaliacao.Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei).Where(a => a.aceite == 0);
        }
        public Avaliacao ObterAvaliacaoPorId(long id)
        {
            return context.Tbl_Avaliacao.Where(a => a.id == id).Include(a => a.usuario).Include(f => f.filial).Include(i => i.imei).First();
        }
        public void GravarAvaliacao(Avaliacao avaliacao)
        {
            if (avaliacao.id == 0)
            {
                context.Tbl_Avaliacao.Add(avaliacao);
            }
            else
            {
                context.Entry(avaliacao).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
        public Avaliacao EliminarAvaliacaoPorId(long id)
        {
            Avaliacao avaliacao = ObterAvaliacaoPorId(id);
            context.Tbl_Avaliacao.Remove(avaliacao);
            context.SaveChanges(); return avaliacao;
        }
    }
}
