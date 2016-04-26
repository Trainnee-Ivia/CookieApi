using Domain.Objetos;
using Infrastructure.Maps;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CookieDbContext : DbContext
    {
        public CookieDbContext() : base("name=CookieDbConnection")
        {
           
        }

        public DbSet<PontoDeVenda> PontosDeVenda { get; set; }
        public DbSet<ItemDoPedido> ItemsDosPedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<HistoricoDeRetiradaDoLote> HistoricoDeRetiradaDosLotes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new PedidoMap());
            modelBuilder.Configurations.Add(new ItemDoPedidoMap());
            modelBuilder.Configurations.Add(new PontoDeVendaMap());
            modelBuilder.Configurations.Add(new LoteMap());
            modelBuilder.Configurations.Add(new HistoricoDeLoteMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
        }
    }
}
