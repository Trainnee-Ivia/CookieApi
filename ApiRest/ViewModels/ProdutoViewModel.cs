using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class ProdutoViewModel
    {
                
        public int Id { get; set; }
        [Required(ErrorMessage = "Digite o Nome")]
        [MinLength(2, ErrorMessage = "Nome deve ter no minimo 2 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage ="Digite os DiasValidos após a fabricação")]
        [Range(5, 100, ErrorMessage = "DiasValidos deve ser no minimo 5")]
        public int? DiasValidos { get; set; }

        [Required(ErrorMessage ="Digite o Preco do produto")]
        [Range(0, 100.0)]
        public decimal? Preco { get; set; }

        public List<object> _Links
        {
            get
            {
                return new List<object>()
                {
                    new { rel="self", href="/produtos/" + Id},
                    new { rel="all", href="/produtos"}
                };
            }
        }
    }
}