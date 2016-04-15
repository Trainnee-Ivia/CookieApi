using System;
using AutoMapper;
using Domain.Objetos;

namespace ApiRest.ViewModels
{
    internal class DomainToViewModelMappingProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<PontoDeVenda, PontoDeVendaViewModel>();
            CreateMap<Lote, LoteViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
        }
    }
}