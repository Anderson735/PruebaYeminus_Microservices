using PruebaYeminus.Models;

namespace PruebaYeminus.Services.Contrato
{
    public interface IProductoService
    {
        Task<List<Producto>> GetProductos();
        Task<bool> EditarProducto(Producto producto);
        Task<bool> EliminarProducto(string codigo);
        Task<bool> AgregarProducto(Producto producto);
        Task<Producto> GetProductoByCodigo(string codigo);
    }
}
