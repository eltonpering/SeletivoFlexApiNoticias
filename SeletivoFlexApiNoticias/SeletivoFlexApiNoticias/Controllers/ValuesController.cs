using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SeletivoFlexApiNoticias.DAO;
using SeletivoFlexApiNoticias.Entidades;

namespace SeletivoFlexApiNoticias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
      
        [HttpPost]
        [Route("Cadastrar")]
        public void CadastrarNoticia([FromBody]Noticias noticia)
        {

            Noticias novaNoticia = new Noticias()
            {
                id_autor = noticia.id_autor,
                Titulo = noticia.Titulo,
                Texto = noticia.Texto
            };

            NoticiasDAO dao = new NoticiasDAO();

            dao.Adiciona(novaNoticia);
        }


        [HttpPost]
        [Route("Editar")]
        public ActionResult<string> EditarNoticia([FromBody]Noticias noticia)
        {
            NoticiasDAO dao = new NoticiasDAO();
            Noticias consultaNoticia = dao.BuscaPorId(noticia.id_noticia);

            if (consultaNoticia != null)
            {
                consultaNoticia.Titulo = noticia.Titulo;
                consultaNoticia.Texto = noticia.Texto;
                dao.Altera();

                return "Noticia Alterada com sucesso!";
            } 


            return "Nao foi possivel alterar a noticia";
        }

        [HttpDelete]
        [Route("Deletar")]
        public ActionResult<string> DeletarNoticia([FromBody]Noticias noticia)
        {
            NoticiasDAO dao = new NoticiasDAO();
            Noticias consultaNoticia = dao.BuscaPorId(noticia.id_noticia);

            if (consultaNoticia != null)
            {
                dao.Remove(consultaNoticia);

                return "Noticia Excluida com sucesso!";
            }


            return "Nao foi possivel localizar a noticia";
        }


        [HttpGet]
        [Route("Pesquisar")]
        public ActionResult<string>  PesquisarNoticia([FromBody]Noticias noticia)
        {
            NoticiasDAO dao = new NoticiasDAO();
            var list = dao.PesquisarNoticias(noticia.Texto);
            var noticias = "";

            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    noticias += item.Autores.Nome + " - " + item.Titulo + " - " + item.Texto + Environment.NewLine;
                }

                return noticias;
            } 
      
            return "nenhum noticia foi encontrada";
        }


        [HttpGet]
        public ActionResult<string>  get()
        {
            NoticiasDAO dao = new NoticiasDAO();
            var list = dao.ConsultarNoticias();
            var noticias = "";

            if (list.Count() > 0)
            {
                foreach (var item in list)
                {
                    noticias += item.Autores.Nome + " - " + item.Titulo + " - " + item.Texto + Environment.NewLine;
                }

                return  "Noticias:" + Environment.NewLine + noticias;
            }

            return "nenhum noticia cadastrada. Utilize as API abaixo:" + Environment.NewLine +
                   "CADASTRAR :_ https://localhost:44331/api/values/Cadastrar" + Environment.NewLine +
                   "EDITAR :  https://localhost:44331/api/values/Editar " + Environment.NewLine +
                   "DELETAR :  https://localhost:44331/api/values/Deletar " + Environment.NewLine +
                   "PESQUISAR :  https://localhost:44331/api/values/Pesquisar " + Environment.NewLine;

        }


    }
}
