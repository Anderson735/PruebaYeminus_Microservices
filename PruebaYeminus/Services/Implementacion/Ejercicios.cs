using PruebaYeminus.Services.Contrato;
using System.Text;

namespace PruebaYeminus.Services.Implementacion
{
    public class Ejercicios : IEjercicios
    {
        public Task<string> DesencriptarPalabra(string palabraEncriptada)
        {
            // Convertir la palabra encriptada a minúsculas
            palabraEncriptada = palabraEncriptada.ToLower();

            // Crear un StringBuilder para construir la palabra desencriptada
            StringBuilder palabraDesencriptada = new StringBuilder();

            // Número fijo para restar a cada letra del alfabeto
            int restaFija = 5;

            // Iterar a través de cada letra de la palabra encriptada
            foreach (char caracter in palabraEncriptada)
            {
                // Comprobar si el caracter es una letra minúscula
                if (char.IsLower(caracter))
                {
                    // Calcular el nuevo caracter desencriptado restando la resta fija al valor ASCII y ajustando si es menor que 'a'
                    char caracterDesencriptado = (char)(((caracter - 'a' - restaFija + 26) % 26) + 'a');
                    // Agregar el caracter desencriptado al resultado
                    palabraDesencriptada.Append(caracterDesencriptado);
                }
                else
                {
                    // Si no es una letra minúscula, simplemente agregar el caracter original
                    palabraDesencriptada.Append(caracter);
                }
            }

            // Devolver la palabra desencriptada como un string dentro de una tarea completada
            return Task.FromResult(palabraDesencriptada.ToString());
        }

        public Task<string> EncriptarPalabra(string palabra)
        {
            // Convertir la palabra a minúsculas para asegurarse de que todas las letras están en el mismo caso
            palabra = palabra.ToLower();

            // Crear un StringBuilder para construir la palabra encriptada
            StringBuilder palabraEncriptada = new StringBuilder();

            // Número fijo para sumar a cada letra del alfabeto
            int sumaFija = 5;

            // Iterar a través de cada letra de la palabra
            foreach (char caracter in palabra)
            {
                // Comprobar si el caracter es una letra minúscula
                if (char.IsLower(caracter))
                {
                    // Calcular el nuevo caracter encriptado sumando la suma fija al valor ASCII y ajustando si supera 'z'
                    char caracterEncriptado = (char)(((caracter - 'a' + sumaFija) % 26) + 'a');
                    // Agregar el caracter encriptado al resultado
                    palabraEncriptada.Append(caracterEncriptado);
                }
                else
                {
                    // Si no es una letra minúscula, simplemente agregar el caracter original
                    palabraEncriptada.Append(caracter);
                }
            }

            // Devolver la palabra encriptada como un string dentro de una tarea completada
            return Task.FromResult(palabraEncriptada.ToString());
        }


        public Task<bool> ValidarNumero(int numero)
        {
            // Función para verificar si un número es un cuadrado perfecto
            bool EsCuadradoPerfecto(int x)
            {
                int raiz = (int)Math.Sqrt(x);
                return raiz * raiz == x;
            }

            // Función para verificar si un número es parte de la serie de Fibonacci
            bool EsParteDeFibonacci(int x)
            {
                // Un número es parte de la serie de Fibonacci si y solo si (5 * n^2 + 4) o (5 * n^2 - 4) es un cuadrado perfecto
                return EsCuadradoPerfecto(5 * x * x + 4) || EsCuadradoPerfecto(5 * x * x - 4);
            }

            // Verificar si el número dado es parte de la serie de Fibonacci
            bool esFibonacci = EsParteDeFibonacci(numero);

            return Task.FromResult(esFibonacci);
        }
    }
}
