using PruebaYeminus.Models;

namespace PruebaYeminus.DTOs
{
    public class ProductoDTO
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public List<decimal> ListaDePrecios { get; set; }
        public string Imagen { get; set; }
        public bool ProductoParaLaVenta { get; set; }
        public int PorcentajeIva { get; set; }
    }
}
