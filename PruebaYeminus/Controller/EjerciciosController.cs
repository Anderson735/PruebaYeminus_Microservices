using Microsoft.AspNetCore.Mvc;
using PruebaYeminus.DTOs;
using PruebaYeminus.Services.Contrato;
using System;
using System.Threading.Tasks;

namespace PruebaYeminus.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class EjerciciosController : ControllerBase
    {
        private readonly IEjercicios _ejerciciosService;

        public EjerciciosController(IEjercicios ejerciciosService)
        {
            _ejerciciosService = ejerciciosService;
        }

        [HttpPost("EncriptarPalabra")]
        public async Task<IActionResult> EncriptarPalabra([FromBody] EjerciciosEncriptacionYDesencriptacionDTO ejercicio)
        {
            try
            {
                if (string.IsNullOrEmpty(ejercicio.Palabra))
                {
                    return BadRequest("La palabra a encriptar no puede estar vacía.");
                }

                var palabraEncriptada = await _ejerciciosService.EncriptarPalabra(ejercicio.Palabra);
                return Ok(palabraEncriptada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("DesencriptarPalabra")]
        public async Task<IActionResult> DesencriptarPalabra([FromBody] EjerciciosEncriptacionYDesencriptacionDTO ejercicio)
        {
            try
            {
                if (string.IsNullOrEmpty(ejercicio.Palabra))
                {
                    return BadRequest("La palabra a desencriptar no puede estar vacía.");
                }

                var palabraDesencriptada = await _ejerciciosService.DesencriptarPalabra(ejercicio.Palabra);
                return Ok(palabraDesencriptada);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost("ValidarNumero")]
        public async Task<IActionResult> ValidarNumero([FromBody] EjercicioFibonacciDTO ejercicio)
        {
            try
            {
                bool esFibonacci = await _ejerciciosService.ValidarNumero(ejercicio.Numero);
                return Ok(new { Numero = ejercicio.Numero, EsFibonacci = esFibonacci });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
