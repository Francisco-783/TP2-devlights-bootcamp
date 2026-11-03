using TP2_devlights_bootcamp.DTOs;
using TP2_devlights_bootcamp.Models;

namespace TP2_devlights_bootcamp.Services;

public interface IProductoService
{
    Task<List<ProductoDto>> GetAllAsync();
    Task<ProductoDto?> GetByIdAsync(int id);
    Task<ProductoDto> CreateAsync(CreateProductoDto createDto);
    Task<ProductoDto?> UpdateAsync(int id, CreateProductoDto updateDto);
    Task<bool> DeleteAsync(int id);
}
