using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvMobile.Models
{
    public class Avaliacao
    {
        public long id { get; set; }
        public int aceite { get; set; }
        public int p1 { get; set; }
        public int p2 { get; set; }
        public int p3 { get; set; }
        public int p4 { get; set; }
        public int p5 { get; set; }
        public float valorAv { get; set; }

        public int usuarioId { get; set; }
        public int imeiId { get; set; }
        public int filialId { get; set; }

        public Usuario usuario { get; set; }
        public Imei imei { get; set; }
        public Filial filial { get; set; }

    }
}