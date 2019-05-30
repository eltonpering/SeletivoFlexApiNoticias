using SeletivoFlexApiNoticias.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SeletivoFlexApiNoticias.DAO
{
    public class NoticiasDAO
    {
        private EntidadeContext contexto;

        /// <summary>
        /// Contexto
        /// </summary>
        public NoticiasDAO()
        {
            this.contexto = new EntidadeContext();
        }

        /// <summary>
        /// Metodo utilzado para Adicionar Autores
        /// </summary>
        /// <param name="autores"></param>
        /// <returns></returns>
        public long Adiciona(Noticias noticia)
        {
            contexto.Noticias.Add(noticia);
            contexto.SaveChanges();

            return noticia.id_noticia;
        }

        /// <summary>
        /// Metodo que altera a Noticia
        /// </summary>
        public void Altera()
        {
            contexto.SaveChanges();
        }

        /// <summary>
        /// Metodo que busca a Noticia por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Noticias BuscaPorId(int id)
        {
            return contexto.Noticias.Find(id);
        }

        /// <summary>
        /// Metodo que remove a noticia
        /// </summary>
        /// <param name="noticias"></param>
        public void Remove(Noticias noticias)
        {
            contexto.Noticias.Remove(noticias);
            contexto.SaveChanges();
        }


        /// <summary>
        /// Metodo que pesquisa a noticia pelo autor, titulo e texto
        /// </summary>
        /// <returns></returns>
        public List<Noticias> PesquisarNoticias(string pesquisa)
        {

            if (!String.IsNullOrEmpty(pesquisa))
            {
                return contexto.Noticias.Where(s => s.Autores.Nome == pesquisa ||
                                                    s.Titulo == pesquisa ||
                                                    s.Texto.ToString() == pesquisa).ToList(); 
            }else
            {
                return new List<Noticias>();
            }
           
        }

        /// <summary>
        /// Metodo que lista todas as noticias
        /// </summary>
        /// <returns></returns>
        public List<Noticias> ConsultarNoticias()
        {
            return contexto.Noticias.OrderBy(s=> s.Titulo).ThenBy(d=> d.Autores.Nome).ToList();
        }

    }
}
