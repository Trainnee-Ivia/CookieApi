using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class LoteMap: EntityTypeConfiguration<Lote>
    {
        public LoteMap()
        {
            ToTable("Lote", "Adm");
            HasKey(l => l.Id);

            Property(l => l.CustoUnitarioDeFabricacao)
                .HasColumnName("Custo")
                .HasColumnType("numeric")
                .HasPrecision(18,2)
                .IsRequired();

            Property(l => l.DataDeFabricacao)
                .HasColumnName("DataFabric")
                .HasColumnType("date")
                .IsRequired();

            Property(l => l.DataDeValidade)
                .HasColumnName("DataVencimento")
                .HasColumnType("date")
                .IsRequired();

            Property(l => l.QuantidadeEmEstoque)
                .HasColumnName("Saldo")
                .HasColumnType("int")
                .IsRequired();

            Property(l => l.QuantidadeFabricada)
                .HasColumnName("Qtde")
                .HasColumnType("int")
                .IsRequired();

            HasRequired(l => l.Produto)
                .WithMany()
                .HasForeignKey(l => l.ProdutoId);

        }
    }
}
