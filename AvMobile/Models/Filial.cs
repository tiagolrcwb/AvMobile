using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvMobile.Models
{
    public class Filial
    {
        public int id { get; set; }
        public string nome { get; set; }

        public int? cidadeId { get; set; }

        public Cidade cidade { get; set; }
        

    }
}