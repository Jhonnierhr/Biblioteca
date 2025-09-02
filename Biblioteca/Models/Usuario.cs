using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Usuario
    {
        //Atributos de la clase usuario
        [Key]
        public int _idUsario { get; set; } // Clave primaria
        public string _nombre { get; set; }
        public string _direccion { get; set; }
        public string _numeroTelefono { get; set; }

        // Constructor
        //public Usuario(int idUsario, string nombre, string direccion, string numeroTelefono)
        //{
        //    _idUsario = idUsario;
        //    _nombre = nombre;
        //    _direccion = direccion;
        //    _numeroTelefono = numeroTelefono;
        //}

        public virtual ICollection<Prestamo> Prestamos { get; set; } = new List<Prestamo>();

        // Método para mostrar la información del usuario
        public string MostrarInfo()
        {
            return $"Id: {_idUsario}\nNombre: {_nombre}\nDirección: {_direccion}\nNúmero de Teléfono: {_numeroTelefono}";
        }
    }
}
