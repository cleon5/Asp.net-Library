using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class LibroModelo
    {
        public int Id_Libro { get; set; }

        [Required(ErrorMessage = "El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El campo Pages es obligatorio")]
        public int? Pages { get; set; }
        [Required(ErrorMessage = "El campo Tipo es obligatorio")]
        public string? Tipo { get; set; }
        [Required(ErrorMessage = "El campo Genero es obligatorio")]
        public string? Genero { get; set; }

    }
}
