# CookieApi
Web API RESTful para praticar o conhecimento adquirido no Trainnee.

## Recursos

+ Produtos.
+ Pontos de Venda.
+ Pedidos.
- Lotes.


### Produtos

#### Paths
>**Lista de produtos**  
>METHOD: GET, POST  
>URL: [http://domain.com/api/produtos](http://domain.com/api/produtos)     

>**Único produto por id**  
>METHOD: GET, PUT, DEL  
>URL: [http://domain.com/api/produtos/{id}](http://domain.com/api/produtos/1)   

#### Template - POST, PUT
```json
{
	"nome" : "Tradicional",
    "preco" : 3.6,
    "diasValidos" : 15
}
```

#### Template - GET
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
