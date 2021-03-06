﻿using System;
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
            CreateMap<Lote, LoteViewModelEnvio>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Pedido, PedidoViewModelEnvio>();
            CreateMap<ItemDoPedido, ItemDoPedidoViewModelEnvio>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}