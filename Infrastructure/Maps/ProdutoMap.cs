using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class ProdutoMap: EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto", "Adm");
            HasKey(p => p.Id);
            

            Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();

            Property(p => p.Preco)
                .HasColumnName("PrecoVenda")
                .HasColumnType("numeric")
                .HasPrecision(18, 2)
                .IsRequired();

            Property(p => p.DiasValidos)
                .HasColumnName("PrazoValidade")
                .HasColumnType("int")
                .IsRequired();
        }
    }
}
