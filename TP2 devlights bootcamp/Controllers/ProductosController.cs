using Microsoft.AspNetCore.Mvc;
using TP2_devlights_bootcamp.DTOs;
using TP2_devlights_bootcamp.Services;

namespace TP2_devlights_bootcamp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductosController : ControllerBase
{
    private readonly IProductoService _service;

    public ProductosController(IProductoService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var productos = await _service.GetAllAsync();
        return Ok(productos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var producto = await _service.GetByIdAsync(id);
        if (producto == null)
            return NotFound(new { mensaje = $"Producto con ID {id} no encontrado" });

        return Ok(producto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductoDto createDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producto = await _service.CreateAsync(createDto);
        return CreatedAtAction(nameof(GetById), new { id = producto.Id }, producto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] CreateProductoDto updateDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var producto = await _service.UpdateAsync(id, updateDto);
        if (producto == null)
            return NotFound(new { mensaje = $"Producto con ID {id} no encontrado" });

        return Ok(producto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var resultado = await _service.DeleteAsync(id);
        if (!resultado)
            return NotFound(new { mensaje = $"Producto con ID {id} no encontrado" });

        return NoContent();
    }
}
