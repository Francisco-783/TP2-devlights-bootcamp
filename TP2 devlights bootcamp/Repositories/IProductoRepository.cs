using TP2_devlights_bootcamp.Models;

namespace TP2_devlights_bootcamp.Repositories;

public interface IProductoRepository
{
    Task<List<Producto>> GetAllAsync();
    Task<Producto?> GetByIdAsync(int id);
    Task<Producto> CreateAsync(Producto producto);
    Task<Producto?> UpdateAsync(int id, Producto producto);
    Task<bool> DeleteAsync(int id);
}
