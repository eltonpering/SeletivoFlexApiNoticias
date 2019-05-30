using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SeletivoFlexApiNoticias.Entidades;


namespace SeletivoFlexApiNoticias
{
    public class EntidadeContext : DbContext
    {
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Noticias> Noticias { get; set; }

        /*String de conexao com banco de dados local para o DBContext*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies()
                .UseSqlServer(@"Server=localhost;Database=BancoTeste;Persist Security Info=True; User ID=UsuarioAplicao;Password=MinhaSenhaSeguraDaAplicacao;  Integrated Security=SSPI");

            optionsBuilder.UseLoggerFactory(new LoggerFactory().AddConsole((category, level) =>
                level == LogLevel.Information &&
                   category == DbLoggerCategory.Database.Command.Name, true));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //------entidade Autor--------------------
            modelBuilder.Entity<Autores>().HasKey(a => a.id_autor);
            modelBuilder.Entity<Autores>()
               .Property(p => p.Nome)
               .HasColumnType("varchar")
               .HasMaxLength(255)
               .IsRequired();


            //------Entidade Noticias--------------------
            modelBuilder.Entity<Noticias>().HasKey(a => a.id_noticia);
            modelBuilder.Entity<Noticias>()
                .Property(p => p.Titulo)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            modelBuilder.Entity<Noticias>()
                .Property(p => p.Texto)
                .HasColumnType("text")
                .IsRequired();

            //um-para-muitos :  Noticias - Autor
            modelBuilder.Entity<Noticias>()
              .HasOne<Autores>(s => s.Autores)
                .WithMany(g => g.Noticias)
                   .HasForeignKey(s => s.id_autor);
           
        }
    }
}
