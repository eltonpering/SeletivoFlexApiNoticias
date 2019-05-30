using SeletivoFlexApiNoticias.Entidades;

namespace SeletivoFlexApiNoticias.DAO
{
    public class AutoresDAO
    {

        private EntidadeContext contexto;

        /// <summary>
        /// Contexto
        /// </summary>
        public AutoresDAO()
        {
            this.contexto = new EntidadeContext();
        }


        /// <summary>
        /// Metodo utilzado para Adicionar Autores
        /// </summary>
        /// <param name="autores"></param>
        /// <returns></returns>
        public long Adiciona(Autores autores)
        {
            contexto.Autores.Add(autores);
            contexto.SaveChanges();

            return autores.id_autor;
        }


       
    }
}
