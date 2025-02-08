using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Models
{
    public class Serie
    {
        public int Id { get; set; }

        [Required]
        public string? Nombre { get; set; }

        [Required]
        public string? Imagen { get; set; }

        [Required]
        public string? EnlaceVideo { get; set; }

        [Required]
        public int ProductoraId { get; set; }
        public Productora? Productora { get; set; }

        [Required]
        public int GeneroPrimarioId { get; set; }
        public Genero? GeneroPrimario { get; set; }

        public int? GeneroSecundarioId { get; set; }
        public Genero? GeneroSecundario { get; set; }
    }
}
