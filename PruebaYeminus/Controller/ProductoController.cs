using AutoMapper;
using PruebaYeminus.DTOs;
using PruebaYeminus.Services.Contrato;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using PruebaYeminus.Models;

namespace PruebaYeminus.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;
        private readonly IMapper _mapper;

        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet("GetProductos")]
        public async Task<IActionResult> GetProductos()
        {
            var listaDeProductos = await _productoService.GetProductos();
            var listaDeProductosDTO = _mapper.Map<List<ProductoDTO>>(listaDeProductos);

            if (listaDeProductosDTO.Count > 0)
            {
                return Ok(listaDeProductosDTO);
            }
            return NoContent();
        }
        [HttpGet("ObtenerPorCodigo/{codigo}")]
        public async Task<IActionResult> GetProductoByCodigo(string codigo)
        {
            var producto = await _productoService.GetProductoByCodigo(codigo);
            if (producto == null)
            {
                return NotFound();
            }

            var productoDTO = _mapper.Map<ProductoDTO>(producto);
            return Ok(productoDTO);
        }

        [HttpPost("AgregarProducto")]
        public async Task<IActionResult> AgregarProducto([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);
                var resultado = await _productoService.AgregarProducto(producto);
                if (resultado)
                {
                    return Ok("Producto agregado exitosamente.");
                }
                return BadRequest("No se pudo agregar el producto.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("EditarProducto/{codigo}")]
        public async Task<IActionResult> EditarProducto(string codigo, [FromBody] ProductoDTO productoDTO)
        {
            try
            {
                var producto = _mapper.Map<Producto>(productoDTO);
                producto.Codigo = codigo;

                var resultado = await _productoService.EditarProducto(producto);
                if (resultado)
                {
                    return Ok("Producto editado exitosamente.");
                }
                return NotFound("Producto no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("EliminarProducto/{codigo}")]
        public async Task<IActionResult> EliminarProducto(string codigo)
        {
            try
            {
                var resultado = await _productoService.EliminarProducto(codigo);
                if (resultado)
                {
                    return Ok("Producto eliminado exitosamente.");
                }
                return NotFound("Producto no encontrado.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
