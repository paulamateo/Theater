using System.ComponentModel.DataAnnotations;

namespace Theater.Models {
    public class ShowUpdateDTO {
        [Required]
        [StringLength(100, ErrorMessage = "Obra no encontrada al intentar actualizarla.")]
        public string? ShowId { get; set; }

    }

}