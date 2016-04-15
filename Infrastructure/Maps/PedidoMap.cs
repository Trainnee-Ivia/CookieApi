using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class PedidoMap: EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido", "Adm");
            HasKey(p => p.Id);

            Property(p => p.DataDoPedido)
                .HasColumnName("DataPedido")
                .HasColumnType("date")
                .IsRequired();

            Property(p => p.PontoDeVendaId)
                .HasColumnName("PontoId")
                .HasColumnType("int")
                .IsRequired();

            HasMany(p => p.ItensDoPedido)
                .WithRequired(idp => idp.Pedido)
                .HasForeignKey(idp => idp.PedidoId);

            HasRequired(p => p.PontoDeVenda)
                .WithMany(pdv => pdv.Pedidos)
                .HasForeignKey(p => p.PontoDeVendaId)
                ;
        }
    }
}
