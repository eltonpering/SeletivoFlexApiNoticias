Solução API Notícias

Foi utilizado o aplicativo Postman para testes.

Segue as parametrizações como exemplo:

-Cadastro de Notícias

Tipo requisição: POST
Url: https://localhost:44331/api/values/Cadastrar
JSon:
      {
        "id_autor": 1,
        "Titulo": "Titulo Testes",
        "Texto": "Texto noticia" 
      }
      
- Ediçao de Notícias

Tipo requisição: POST
Url: https://localhost:44331/api/values/Editar
JSon:
      {
        "id_autor": 1,
        "Titulo": "Titulo Testes 2",
        "Texto": "Texto noticia 2" 
      }
      
 - Exclusão de Notícias

Tipo requisição: DELETE
Url: https://localhost:44331/api/values/Deletar
JSon:
    {
	    "id_noticia": 1
    }
    
 - Listar todas as Notícias

Tipo requisição: GET
Url: https://localhost:44331/api/values/Listar


 - Pesquisar a Notícia por texto nos campos Autor, Titulo e Texto

Tipo requisição: GET
Url: https://localhost:44331/api/values/Pesquisar
JSon:
    {
	    "Texto": "Texto noticia" 
    }
