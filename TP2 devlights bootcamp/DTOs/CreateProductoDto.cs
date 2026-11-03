using System.ComponentModel.DataAnnotations;

namespace TP2_devlights_bootcamp.DTOs;

public class CreateProductoDto
{
    [Required(ErrorMessage = "El nombre es requerido")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 100 caracteres")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "El precio es requerido")]
    [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
    public decimal Precio { get; set; }

    [Required(ErrorMessage = "La categoría es requerida")]
    public string Categoria { get; set; } = string.Empty;
}
