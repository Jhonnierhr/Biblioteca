using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.Marshalling;

namespace Biblioteca.Models
{
    public class Libro
    {
        //Atributos de clase
        [Key]
        public int _idLibro {  get; set; }
        public string _titulo { get; set; }
        public string _autor {  get; set; }
        public string _genero { get; set; }
        public int _añoDePublicacion { get; set; }

        //Constructor
        //public Libro(int idLibro, string titulo, string autor, string genero, int añoDePublicacion)
        //{
        //    _idLibro = idLibro;
        //    _titulo = titulo;
        //    _autor = autor;
        //    _genero = genero;
        //    _añoDePublicacion = añoDePublicacion;
        

        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        //Método para mostrar la información del libro
        public string MostrarInfo()
        {
            return $"Id: {_idLibro}\nTítulo: {_titulo}\nAutor: {_autor}\nGénero: {_genero}\nAño de Publicación: {_añoDePublicacion}";
        }

    }
}

