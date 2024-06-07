using AutoMapper;
using PruebaYeminus.DTOs;
using PruebaYeminus.Models;
using System.Globalization;

namespace PruebaYeminus.Utilidades
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Producto
            {
                CreateMap<Producto, ProductoDTO>()
                    .ForMember(dest => dest.ListaDePrecios, opt => opt.MapFrom(src => src.ListaDePrecios.Select(lp => lp.Precio).ToList()));

                CreateMap<ProductoDTO, Producto>()
                    .ForMember(dest => dest.ListaDePrecios, opt => opt.MapFrom(src => src.ListaDePrecios.Select(precio => new ListaDePrecio { Precio = precio }).ToList()));

            }
            #endregion
        }
    }
}
