using PruebaYeminus.Models;

namespace PruebaYeminus.Services.Contrato
{
    public interface IListaDePrecioService
    {
        Task<List<ListaDePrecio>> GetListaDePrecios();
    }
}
