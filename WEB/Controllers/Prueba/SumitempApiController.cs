using CanonicalModel.Model.Configuration;
using CanonicalModel.Model.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WEB.Controllers.Prueba
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumitempApiController : ControllerBase
    {
        /// <summary>
        ///1 ¿Cuál es el resultado después de ejecutar el algoritmo?
        ///R / D Resultado 1: 69 Resultado 2: 49,8
        /// </summary>
        /// <returns></returns>
        [Route("[action]", Name = "GetTest")]
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            AuthResult responseClient = new AuthResult();
             responseClient.ResponseTex =await Get();
            GetPersona();
            return Ok(new {responseClient});
        }
        public async Task<string> Get()
        {
            List<Persona> personas = new();
            personas.Add(new Persona { identificacion = "79658321", nombres = "Pedro Estiven", apellidos = "Gil Barón", FechaNacimiento = DateTime2("1979,10,26") });
            personas.Add(new Persona { identificacion = "41582329", nombres = "Ana María", apellidos = "López Torres", FechaNacimiento = DateTime2("1954,08, 12") });
            personas.Add(new Persona { identificacion = "84632206", nombres = "Eugenio", apellidos = "Joya Rivera", FechaNacimiento = DateTime2("1984, 05, 17") });
            personas.Add(new Persona { identificacion = "7456977", nombres = "Carol Johanna", apellidos = "Pérez Castro", FechaNacimiento = DateTime2("1975, 02,5") });
            personas.Add(new Persona { identificacion = "15608542", nombres = "Pablo Raúl", apellidos = "Téllez Sánchez", FechaNacimiento = DateTime2("1949,01,19") });
            string result = ProcesarPersona(personas);
            return result;
        }

        public string ProcesarPersona(List<Persona> personas)
        {
            decimal Resultado1 = 0;
            decimal Resultado2 = 0;
            int valor = 0;
            DateTime fechaActual = new DateTime(2018, 3, 23);
            foreach (Persona p in personas)
            {
                valor = calcularEdad( p.FechaNacimiento, fechaActual);
                if (valor > Resultado1) { Resultado1 = valor; }
                Resultado2 = Resultado2 + valor;
            }
            Resultado2 = Resultado2 / personas.Count;
            return "Resultado 1:" +Resultado1 + "Resultado 2:" +Resultado2;
        }

        private static int calcularEdad(DateTime FechaNacimiento,DateTime fechaActual) 
        {
            //DateTime now = DateTime.Today;
            //var now = fechaActual.Day;

            int edad = fechaActual.Year - FechaNacimiento.Year;
            if (DateTime.Today < FechaNacimiento.AddYears(edad))
                edad--;
            return edad;
        }

        private static DateTime DateTime2(string value)
        {
            return Convert.ToDateTime(value);
        }

        /// <summary>
        /// 2. ¿Cuál de las siguientes opciones muestra la información completa de la persona?
        /// </summary>
        private static void GetPersona()
        {
            Persona p = new();
            DateTime fechaActual = new DateTime(2018, 3, 23);
            p = (new Persona { identificacion = "79658321", nombres = "Pedro Estiven", apellidos = "Gil Barón", FechaNacimiento = DateTime2("1979,10,26") });

            var A=("Identificación: { 0}; Nombres: { 1}; Apellidos: { 2}; Edad:{ 3}", p.identificacion, p.nombres, p.apellidos, calcularEdad(p.FechaNacimiento, fechaActual));
            var B=("Identificación: " +p.identificacion + " Nombres: " + p.nombres + "Apellidos: " +p.apellidos + "Edad: " +p.edad);
            var C=(String.Concat("Identificación: ", p.identificacion, "Nombres: ", p.nombres, "Apellidos: ", p.apellidos, "Edad: ", p.edad));
            //D a y b son correctas.
        }
    }
}
