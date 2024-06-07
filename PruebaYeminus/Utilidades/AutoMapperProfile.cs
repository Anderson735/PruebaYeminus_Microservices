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
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            #endregion
        }
    }
}
