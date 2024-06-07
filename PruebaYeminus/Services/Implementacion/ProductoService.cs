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
    }
}
