using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvMobile.Models
{
    public class Usuario
    {
        public int id { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public int grupo { get; set; }
        public int? filialId { get; set; }
        public Filial filial { get; set; }
    }
}