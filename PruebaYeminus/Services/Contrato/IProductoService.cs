using PruebaYeminus.Models;

namespace PruebaYeminus.Services.Contrato
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
    }
}
