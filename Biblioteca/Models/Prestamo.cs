using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Models
{
    public class Prestamo
    {
        [Key]
        public int _idPrestamo { get; set; } // Clave primaria
        public int _idLibro { get; set; } // Clave foránea
        public int _idUsuario { get; set; } // Clave foránea
        public DateTime _fechaInicio { get; set; }
        public DateTime _fechaFin { get; set; }

        // Claves foráneas (relaciones de navegación)
        [ForeignKey("_idLibro")]
        public Libro Libro { get; set; }

        [ForeignKey("_idUsuario")]
        public Usuario Usuario { get; set; }

        // Constructor
        //public Prestamo(int id, int idLibro, int idUsuario, DateTime fechaInicio, DateTime fechaFin)
        //{
        //    _idPrestamo = id;
        //    _idLibro = idLibro;
        //    _idUsuario = idUsuario;
        //    _fechaInicio = fechaInicio;
        //    _fechaFin = fechaFin;
        //}

        // Método para mostrar la información del préstamo
        public string MostrarInfo()
        {
            return $"IdPrestamo: {_idPrestamo}\nId del Libro: {_idLibro}\nId del Usuario: {_idUsuario}\nFecha de Inicio: {_fechaInicio:dd/MM/yyyy}\nFecha de Fin: {_fechaFin:dd/MM/yyyy}";
        }
    }
}
