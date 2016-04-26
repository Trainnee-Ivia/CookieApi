using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; }
        public string TipoUser { get; set; }

        
    }
}