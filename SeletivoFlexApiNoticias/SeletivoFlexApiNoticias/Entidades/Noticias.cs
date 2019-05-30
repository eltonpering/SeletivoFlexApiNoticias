using System.ComponentModel.DataAnnotations;


namespace SeletivoFlexApiNoticias.Entidades
{
    public class Noticias
    {
        [Key]
        public int id_noticia { get; set; }

       
        public int id_autor { get; set; }

        public string Titulo { get; set; }

        public string Texto { get; set; }


        public virtual Autores Autores { get; set; }

    }
}
