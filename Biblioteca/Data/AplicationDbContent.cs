using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;


namespace Biblioteca.Data
{
    public class AplicationDbContent : DbContext
    {
        public AplicationDbContent(DbContextOptions<AplicationDbContent> options) : base(options)
        {
        }

        public DbSet<Libro> Libros {  get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
