﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvMobile.Models
{
    public class Imei
    {
        public int id { get; set; }
        public long num_imei { get; set; }

        public int? aparelhoId { get; set; }

        public Aparelho aparelho { get; set; }
    }
}