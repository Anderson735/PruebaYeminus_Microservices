using AutoMapper;
using PruebaYeminus.DTOs;
using PruebaYeminus.Services.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace PruebaYeminus.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductoController : ControllerBase
    {
        private IProductoService _productoService;
        private IMapper _mapper;
        // GET: DepartamentoController
        public ProductoController(IProductoService productoService, IMapper mapper)
        {
            _productoService = productoService;
            _mapper = mapper;
        }

        [HttpGet("GetProductos")]
        public async Task<IResult> GetDepartamento()
        {
            var listaDeProductos = await _productoService.GetProductos();
            var listaDeProductosDTO = _mapper.Map<List<ProductoDTO>>(listaDeProductos);

            if (listaDeProductosDTO.Count > 0)
            {
                return Results.Ok(listaDeProductosDTO);
            }
            return Results.NoContent();
        }

       
    }
}
