using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvMobile.Models
{
    public class Cidade
    {
        public int id { get; set; }
        public string nome { get; set; }
        public int estadoId { get; set; }
        public Estado estado { get; set; }
       // public virtual ICollection<Estado> estados { get; set; }
    }
}