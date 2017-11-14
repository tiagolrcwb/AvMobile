using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Modelo.Cadastros
{
    public class Avaliacao
    {
        [DisplayName("Id da Avaliação")]
        public long id { get; set; }
        [DisplayName("Aceite")]
        public int aceite { get; set; }
        [DisplayName("1º Criterio")]
        public int p1 { get; set; }
        [DisplayName("2º Criterio")]
        public int p2 { get; set; }
        [DisplayName("3º Criterio")]
        public int p3 { get; set; }
        [DisplayName("4º Criterio")]
        public int p4 { get; set; }
        [DisplayName("5º Criterio")]
        public int p5 { get; set; }
        [DisplayName("Valor Avaliado")]
        public float valorAv { get; set; }
        [DisplayName("Observações")]
        public string obs { get; set; }

        [DisplayName("Usuario Avaliação")]
        public int usuarioId { get; set; }
        [DisplayName("Numero do IMEI")]
        [Required(ErrorMessage = "Informe o Aparelho")]
        public int imeiId { get; set; }
        [DisplayName("Filial Avaliação")]
        
        public int filialId { get; set; }

        public Usuario usuario { get; set; }
        public Imei imei { get; set; }
        public Filial filial { get; set; }

    }
}