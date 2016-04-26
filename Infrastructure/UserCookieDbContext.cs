using Infrastructure.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Infrastructure
{
    
    class UserCookieDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public UserCookieDbContext() : base("name=CookieDbConnection", false)
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Adm");

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
            .ToTable("Usuarios")
            .Property(p => p.Nome)
            .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .Property(p => p.TipoUser)
                .IsRequired();

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Usuarios")
                .Property(p => p.Id)
                .HasColumnName("UsuarioId");

            modelBuilder.Entity<IdentityUserRole>()
                .ToTable("UsuarioPapel");

            modelBuilder.Entity<IdentityUserLogin>()
                .ToTable("Logins");

            modelBuilder.Entity<IdentityUserClaim>()
                .ToTable("Claims");

            modelBuilder.Entity<IdentityRole>()
                .ToTable("Papeis");

        }
    }
}
