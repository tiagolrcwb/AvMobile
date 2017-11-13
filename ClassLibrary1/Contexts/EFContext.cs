using Modelo.Cadastros;
using Modelo.Tabelas;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Persistencia.Contexts
{
    public class EFContext : DbContext
    {
        public DbSet<Aparelho> Tbl_Aparelho { get; set; }
        public DbSet<Imei> Tbl_Imei { get; set; }
        public DbSet<Usuario> Tbl_Usuario { get; set; }
        public DbSet<Filial> Tbl_Filial { get; set; }
        public DbSet<Cidade> Tbl_Cidade { get; set; }
        public DbSet<Estado> Tbl_Estado { get; set; }
        public DbSet<Avaliacao> Tbl_Avaliacao { get; set; }

        public EFContext() : base("AvaliaMobile")
        {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

       
    }
}