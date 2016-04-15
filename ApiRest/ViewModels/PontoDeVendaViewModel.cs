using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class PontoDeVendaViewModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="Digite algum telefone.")]
        [MinLength(8, ErrorMessage ="Telefone invalido.")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Ponto De Venda.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Digite o Nome do Contato.")]
        public string NomeDoContato { get; set; }
        [Required(ErrorMessage ="Digite o Endereço")]
        public EnderecoViewModel Endereco { get; set; }
    }
}