# CookieApi
Web API RESTful para praticar o conhecimento adquirido no Trainnee.

## Recursos

+ Produtos.
+ Pontos de Venda.
+ Pedidos.
- Lotes.


### Produtos

#### Paths
Lista de produtos [/api/produtos](http://domain.com/api/produtos) metodos GET, POST  
Unico produto por id [/api/produtos/{id}](http://domain.com/api/produtos/1) metodos GET, PUT, DEL

#### Template
#####   POST
```json
    {
        "nome" : "Tradicional",
        "preco" : 3.6,
        "diasValidos" : 15
    }
```
