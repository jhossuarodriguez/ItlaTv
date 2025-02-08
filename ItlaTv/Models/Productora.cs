using System.ComponentModel.DataAnnotations;

namespace ItlaTv.Models
{
    public class Productora
    {
        public int Id { get; set; }

       [Required]
        public string? Nombre { get; set; }
    }
}
