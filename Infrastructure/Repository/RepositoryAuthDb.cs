using Infrastructure.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class RepositoryAuthDb: IDisposable
    {
        private UserCookieDbContext _ctx;

        private UserManager<ApplicationUser> _userManager;

        public RepositoryAuthDb()
        {
            _ctx = new UserCookieDbContext();
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_ctx));
        }

        public IdentityResult RegisterUser(UserModel userModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                PhoneNumber = userModel.Telefone,
                Nome = userModel.Nome,
                UserName = userModel.Email,
                Email = userModel.Email,
                TipoUser = "Ponto"
            };

            var result = _userManager.Create(user, userModel.Password);
            
            return result;
        }

        public async Task<ApplicationUser> FindUser(string userName, string password)
        {
            ApplicationUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
