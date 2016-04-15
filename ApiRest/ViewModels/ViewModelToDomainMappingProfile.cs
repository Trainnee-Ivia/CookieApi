using System;
using AutoMapper;
using Domain.Objetos;

namespace ApiRest.ViewModels
{
    internal class ViewModelToDomainMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<LoteViewModel, Lote>();
            CreateMap<PontoDeVendaViewModel, PontoDeVenda>();
            CreateMap<EnderecoViewModel, Endereco>();

        }
    }
}