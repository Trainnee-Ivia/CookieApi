using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class ItemDoPedidoMap: EntityTypeConfiguration<ItemDoPedido>
    {
        public ItemDoPedidoMap()
        {
            ToTable("ItensDoPedido", "Adm");
            HasKey(idp => idp.Id);

            Property(idp => idp.PrecoUnitarioDoProduto)
                .HasColumnName("PrecoVendido")
                .HasColumnType("numeric")
                .HasPrecision(18,2)
                .IsRequired();

            Property(idp => idp.Quantidade)
                .HasColumnName("Qtde")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(idp => idp.Pedido)
                .WithMany(p => p.ItensDoPedido)
                .HasForeignKey(idp => idp.PedidoId);

            HasRequired(idp => idp.Produto)
                .WithMany()
                .HasForeignKey(idp => idp.ProdutoId);


        }
    }
}
