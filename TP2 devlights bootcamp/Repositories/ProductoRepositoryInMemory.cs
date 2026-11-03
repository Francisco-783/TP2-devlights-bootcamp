using TP2_devlights_bootcamp.Models;

namespace TP2_devlights_bootcamp.Repositories;

public class ProductoRepositoryInMemory : IProductoRepository
{
    private static List<Producto> productos = new();
    private static int idCounter = 1;

    public Task<List<Producto>> GetAllAsync()
    {
        return Task.FromResult(productos.ToList());
    }

    public Task<Producto?> GetByIdAsync(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(producto);
    }

    public Task<Producto> CreateAsync(Producto producto)
    {
        producto.Id = idCounter++;
        productos.Add(producto);
        return Task.FromResult(producto);
    }

    public Task<Producto?> UpdateAsync(int id, Producto productoActualizado)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
            return Task.FromResult<Producto?>(null);

        producto.Nombre = productoActualizado.Nombre;
        producto.Precio = productoActualizado.Precio;
        producto.Categoria = productoActualizado.Categoria;
        producto.Activo = productoActualizado.Activo;

        return Task.FromResult<Producto?>(producto);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var producto = productos.FirstOrDefault(p => p.Id == id);
        if (producto == null)
            return Task.FromResult(false);

        productos.Remove(producto);
        return Task.FromResult(true);
    }
}
