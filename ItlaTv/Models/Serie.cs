using System.ComponentModel;
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
        [DisplayName("Link del Trailer")]
        public string? EnlaceVideo { get; set; }

        [Required]
        [DisplayName("Productora")]
        public int ProductoraId { get; set; }
        public Productora? Productora { get; set; }

        [Required]
        [DisplayName("Genero Primario")]
        public int GeneroPrimarioId { get; set; }
        public Genero? GeneroPrimario { get; set; }

        [DisplayName("Genero Secundario")]
        public int? GeneroSecundarioId { get; set; }
        public Genero? GeneroSecundario { get; set; }
    }
}
