using Domain.Objetos;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Maps
{
    public class PontoDeVendaMap: EntityTypeConfiguration<PontoDeVenda>
    {
        public PontoDeVendaMap()
        {
            ToTable("PontoDeVenda", "Adm");
            HasKey(pdv => pdv.Id);

            Property(pdv => pdv.Id).HasColumnName("Id").HasColumnType("int").IsRequired();

            Property(pdv => pdv.Nome)
                .HasColumnName("Nome")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            Property(pdv => pdv.Telefone)
                .HasColumnName("Telefone")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

            Property(pdv => pdv.NomeDoContato)
                .HasColumnName("Contato")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            Property(pdv => pdv.Endereco.Logradouro)
                .HasColumnName("EnderecoLog")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsRequired();

            Property(pdv => pdv.Endereco.Numero)
                .HasColumnName("EnderecoNum")
                .HasColumnType("int")
                .IsRequired();

            Property(pdv => pdv.Endereco.Complemento)
                .HasColumnName("EnderecoCompl")
                .HasColumnType("varchar")
                .HasMaxLength(60)
                .IsOptional();

            Property(pdv => pdv.Endereco.CEP)
                .HasColumnName("EnderecoCEP")
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();

           
        }
    }
}
