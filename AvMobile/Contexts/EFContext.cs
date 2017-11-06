using AvMobile.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AvMobile.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("AvaliaMobile") {
            Database.SetInitializer<EFContext>(
                new DropCreateDatabaseIfModelChanges<EFContext>());
        }

        public DbSet<Aparelho> Tbl_Aparelho { get; set; }
        public DbSet<Imei> Tbl_Imei { get; set; }
        public DbSet<Usuario> Tbl_Usuario { get; set; }
        public DbSet<Filial> Tbl_Filial { get; set; }
        public DbSet<Cidade> Tbl_Cidade { get; set; }
        public DbSet<Estado> Tbl_Estado { get; set; }
    }
}