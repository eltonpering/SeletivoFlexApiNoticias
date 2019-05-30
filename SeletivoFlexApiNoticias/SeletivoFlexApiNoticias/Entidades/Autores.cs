using System.Collections.Generic;

namespace SeletivoFlexApiNoticias.Entidades
{
    public class Autores
    {
        public int id_autor { get; set; }

        public string Nome { get; set; }

        public virtual ICollection<Noticias> Noticias { get; set; }

    }
}
