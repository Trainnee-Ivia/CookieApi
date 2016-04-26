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
            CreateMap<LoteViewModelRecebimento, Lote>();
            CreateMap<PontoDeVendaViewModel, PontoDeVenda>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<PedidoViewModelRecebimento, Pedido>();
            CreateMap<ItemDoPedidoViewModelRecebimento, ItemDoPedido>();
            CreateMap<UsuarioViewModel, Usuario>();

        }
    }
}