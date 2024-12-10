using AsfaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace AsfaAPI.Data
{
    public class AsfaContext : DbContext
    {
        public AsfaContext(DbContextOptions<AsfaContext> options) : base(options)
        {
        }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Apunte> Apuntes { get; set; }
        public DbSet<PreguntaCategoria> PreguntaCategorias { get; set; }
        public DbSet<Dificultad> Dificultades { get; set; }
        public DbSet<Duda> Dudas { get; set; }
        public DbSet<Examen> Examenes { get; set; }
        public DbSet<Fallo> Fallos { get; set; }
        public DbSet<Pregunta> Preguntas { get; set; }
        public DbSet<Resolucion> Resoluciones { get; set; }
        public DbSet<Respuesta> Respuestas { get; set; }

    }
}
