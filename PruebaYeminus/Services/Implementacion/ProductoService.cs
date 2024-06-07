using Microsoft.EntityFrameworkCore;
using PruebaYeminus.Models;
using PruebaYeminus.Services.Contrato;

namespace PruebaYeminus.Services.Implementacion
{
    public class ProductoService : IProductoService
    {
		private PruebaYeminusContext _dbContext;

        public ProductoService(PruebaYeminusContext dbContext)
        {
			_dbContext = dbContext;
        }
        public async Task<List<Producto>> GetProductos()
        {
			try
			{
                return await _dbContext.Productos
                             .Include(p => p.ListaDePrecios)
                             .ToListAsync();
            }
			catch (Exception ex)
			{

				throw ex;
			}
        }
       public async Task<Producto> GetProductoByCodigo(string codigo)
        {
            try
            {
                return await _dbContext.Productos
                                .Include(p => p.ListaDePrecios)
                                .FirstOrDefaultAsync(p => p.Codigo == codigo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> AgregarProducto(Producto producto)
        {
            try
            {
                _dbContext.Productos.Add(producto);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> EditarProducto(Producto producto)
        {
            try
            {
                var productoExistente = await _dbContext.Productos
                    .Include(p => p.ListaDePrecios)
                    .FirstOrDefaultAsync(p => p.Codigo == producto.Codigo);

                if (productoExistente != null)
                {
                    productoExistente.Descripcion = producto.Descripcion;
                    productoExistente.Imagen = producto.Imagen;
                    productoExistente.ProductoParaLaVenta = producto.ProductoParaLaVenta;
                    productoExistente.PorcentajeIva = producto.PorcentajeIva;

                    // Limpiar la lista de precios existente para evitar duplicados
                    productoExistente.ListaDePrecios.Clear();

                    // Agregar los nuevos precios
                    foreach (var precio in producto.ListaDePrecios)
                    {
                        // Asegurarse de que el precio no sea null
                        if (precio != null)
                        {
                            // Agregar el precio al producto existente
                            productoExistente.ListaDePrecios.Add(precio);
                        }
                    }

                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> EliminarProducto(string codigo)
        {
            try
            {
                var producto = await _dbContext.Productos
                    .Include(p => p.ListaDePrecios)
                    .FirstOrDefaultAsync(p => p.Codigo == codigo);

                if (producto != null)
                {
                    _dbContext.Productos.Remove(producto);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Aquí estamos capturando la excepción y lanzándola de nuevo para que pueda ser manejada en un nivel superior
                throw new Exception("Error al eliminar el producto. Consulte la excepción interna para obtener más detalles.", ex);
            }
        }
    }
}
