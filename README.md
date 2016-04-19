# **CookieApi**
Web API RESTful para praticar o conhecimento adquirido no Trainnee.

## **Recursos**

+ Produtos.
+ Pontos de Venda.
+ Pedidos.
- Lotes.

## **Paths**

### Produtos
> **URL:** */api/produtos*
>**Methods:** *GET, POST*

> **URL:** */api/produtos{/id_produto}*
>**Methods:** *GET, PUT, DELETE*

### Lotes
>**URL:** */api/lotes*
>**Methods:** *GET, POST*

>**URL:** /api/lotes{/id_lote}
>**Methods:** *GET, PUT, DELETE*

### Pontos
>**URL:** */api/pontos*
>**Methods:** *GET, POST*

>**URL:** */api/pontos{/id_ponto}*
>**Methods:** *GET, PUT, DELETE*

### Pedidos
>**URL:** */api/pedidos*
>**Methods:** *GET, POST*

>**URL:** */api/pedidos{/id_pedido}**
>**Methods:** *GET, PUT, DELETE*

>**URL:** */api/pedidos{/id_pedido}/itens*
>**Methods:** *GET*

>**URL:** */api/pedidos{/id_pedido}/itens{/id_item}*
>**Methods:** *GET*

 
## **Templetes**

####**Template Produto **

- POST, PUT
```json
{
	"nome" : "Tradicional",
    "preco" : 3.6,
    "diasValidos" : 15
}
```

 - GET
```json
{
	"id": 1,
	"nome" : "Tradicional",
    "preco" : 3.6,
    "diasValidos" : 15,
    "_links" : [
	    { 
		    "rel": "self",
		    "href": "http://domain.com/produtos/1"
		},
		{
			"rel": "all",
			"href": "http://domain.com/produtos"
		}
    ]
}
```

#### **Template Lote **
- POST, PUT
```json
{
	"dataDeFabricacao" : "yyyy-MM-dd",
	"quantidadeFabricada" : 5,
	"custoUnitarioDeFabricacao" : 2.00,
	"produtoId": 1
}
```

- GET

```json
{
	"id": 1,
	"dataDeFabricacao" : "2016-04-04",
	"dataDeValidade": "2016-04-19",
	"quantidadeFabricada" : 5,
	"quantidadeEmEstoque" : 5,
	"custoUnitarioDeFabricacao" : 2.00,
	"_links": [
		{
			"rel" : "self",
			"href" : "/api/lotes/1"
		},
		{
			"rel" : "produto",
			"href" : "/api/produtos/1"
		},
		{
			"rel" : "all",
			"href" : "/api/lotes"
		}
	]
}
```

#### **Templete Ponto de Venda**

- POST, PUT
```json
	{
		"nome" : "Ponto 1",
		"nomeContato" : "Michel",
		"telefone": "85992334432",
		"endereco" : {
			"logradouro": "Conjunto Tancredo Neves, Rua da Amizade",
			"numero": 123,
			"complemento"? : "A",
			"cep" : "60820111" 
		}
	}
```

- GET
```json
	{
		"id" : 1
		"nome" : "Ponto 1",
		"nomeContato" : "Michel",
		"telefone": "85992334432",
		"endereco" : {
			"logradouro": "Conjunto Tancredo Neves, Rua da Amizade",
			"numero": 123,
			"complemento"? : "A",
			"cep" : "60820111" 
		},
		"_links" : [
			{
				"rel" : "self",
				"href" : "/api/pontos/1" 
			},
			{
				"rel" : "all",
				"href" : "/api/pontos"
			}
		]
	}
```

#### **Templete Pedido**

- POST, PUT
```json
{
	"dataDoPedido" : "yyyy-MM-dd",
	"pontoDeVendaId" : 1,
	"itensDoPedido": [
		{
			"quantidade" : 12,
			"produtoId" : 1 
		},
		...
	]
}
```

- GET
```json
{
	"id" : 1,
	"dataDoPedido" : "yyyy-MM-dd",
	"_links": [
		{
			"rel" : "self"
			"href" : "/api/pedidos/1"
		},
		{
			"rel" : "all",
			"href" : "/api/pedidos"
		},
		{
			"rel" : "itens",
			"href": "/api/pedidos/1/itens"
		},
		{
			"rel" : "ponto",
			"href" : "/api/pontos/1"
		}
	]
}
```

#### **Templete Itens do Pedido**

- GET

  ```json
	{
		"id" : 1,
		"quantidade" : 20,
		"precoUnitarioDoProduto" : 3.20,
		"_links": [
			{
				"rel" : "self"
				"href" : "/api/pedidos/1/itens/1"
			},
			{
				"rel" : "all",
				"href" : "/api/pedidos/1/itens"
			},
			{
				"rel" : "pedido",
				"href": "/api/pedidos/1"
			},
			{
				"rel" : "produto",
				"href" : "/api/produtos/1"
			}
	    ]
	}
  ```