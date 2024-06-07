using System;
using System.Collections.Generic;

namespace PruebaYeminus.Models;

public partial class ListaDePrecio
{
    public int Id { get; set; }

    public string? CodigoProducto { get; set; }

    public decimal? Precio { get; set; }

    public virtual Producto? CodigoProductoNavigation { get; set; }
}
