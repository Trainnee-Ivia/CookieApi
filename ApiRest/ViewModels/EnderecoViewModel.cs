using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage ="Digite o Logradouro")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Digite o Numero do Ponto de Venda")]
        public int Numero { get; set; }
        
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Digite o CEP")]
        [MinLength(11, ErrorMessage ="CEP invalido.")]
        public string CEP { get; set; }
    }
}