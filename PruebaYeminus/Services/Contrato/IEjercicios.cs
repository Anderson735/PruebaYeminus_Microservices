using PruebaYeminus.Models;

namespace PruebaYeminus.Services.Contrato
{
    public interface IEjercicios
    {
        Task<string> EncriptarPalabra(string palabra);
        Task<string> DesencriptarPalabra(string palabraEncriptada);
        Task<bool> ValidarNumero(int numero);
    }
}
