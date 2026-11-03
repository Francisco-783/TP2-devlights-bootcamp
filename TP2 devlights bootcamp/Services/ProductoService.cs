using TP2_devlights_bootcamp.DTOs;
using TP2_devlights_bootcamp.Models;
using TP2_devlights_bootcamp.Repositories;

namespace TP2_devlights_bootcamp.Services;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _repository;

    public ProductoService(IProductoRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<ProductoDto>> GetAllAsync()
    {
        var productos = await _repository.GetAllAsync();
        return productos.Select(p => MapToDto(p)).ToList();
    }

    public async Task<ProductoDto?> GetByIdAsync(int id)
    {
        var producto = await _repository.GetByIdAsync(id);
        return producto != null ? MapToDto(producto) : null;
    }

    public async Task<ProductoDto> CreateAsync(CreateProductoDto createDto)
    {
        var producto = new Producto
        {
            Nombre = createDto.Nombre,
            Precio = createDto.Precio,
            Categoria = createDto.Categoria,
            Activo = true
        };

        var productoCreado = await _repository.CreateAsync(producto);
        return MapToDto(productoCreado);
    }

    public async Task<ProductoDto?> UpdateAsync(int id, CreateProductoDto updateDto)
    {
        var productoActualizado = new Producto
        {
            Nombre = updateDto.Nombre,
            Precio = updateDto.Precio,
            Categoria = updateDto.Categoria
        };

        var producto = await _repository.UpdateAsync(id, productoActualizado);
        return producto != null ? MapToDto(producto) : null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _repository.DeleteAsync(id);
    }

    private ProductoDto MapToDto(Producto producto)
    {
        return new ProductoDto
        {
            Id = producto.Id,
            Nombre = producto.Nombre,
            Precio = producto.Precio,
            Categoria = producto.Categoria,
            Activo = producto.Activo
        };
    }
}
