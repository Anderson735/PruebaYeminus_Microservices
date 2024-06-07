using System;
using System.Collections.Generic;

namespace PruebaYeminus.Models;

public partial class Producto
{
    public string Codigo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Imagen { get; set; }

    public bool? ProductoParaLaVenta { get; set; }

    public int? PorcentajeIva { get; set; }

    public virtual ICollection<ListaDePrecio> ListaDePrecios { get; } = new List<ListaDePrecio>();
}
