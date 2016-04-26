using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiRest.ViewModels
{
    public class UsuarioViewModel
    {
        public string UsuarioId { get; set; }
        
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TipoUser { get; set; }
        public string PhoneNumber { get; set; }
    }
}