using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class HistoricoDeLoteMap : EntityTypeConfiguration<HistoricoDeRetiradaDoLote>
    {

        public HistoricoDeLoteMap()
        {
            ToTable("HistoricoLotes", "Adm");
            HasKey(hl => hl.Id);
            Property(hl => hl.QuantidadeRetirada)
                .HasColumnName("Qtde")
                .HasColumnType("int")
                .IsRequired();

            Property(hl => hl.ItemDoPedidoId)
                .HasColumnName("ItemPedidoId")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(hl => hl.ItemDoPedido)
                .WithMany(ip => ip.HistoricoDeRetiradaDosLotes)
                .HasForeignKey(hl => hl.ItemDoPedidoId);

            HasRequired(hl => hl.Lote)
                .WithMany()
                .HasForeignKey(hl => hl.LoteId);
        }
    }
}
