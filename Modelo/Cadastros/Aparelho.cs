﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo.Cadastros
{
    public class Aparelho
    {
        public int id { get; set; }
        public string modelo { get; set; }
        public float valor { get; set; }

        //public virtual ICollection<Imei> imeis { get; set; }
    }
}