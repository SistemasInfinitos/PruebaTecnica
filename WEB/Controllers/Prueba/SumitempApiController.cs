using CanonicalModel.Model.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            List<Personas> personas = new();
            personas.Add(new Personas { identificacion = "79658321", nombres = "Pedro Estiven", apellidos = "Gil Barón", FechaNacimiento = DateTime2("1979,10,26") });
            personas.Add(new Personas { identificacion = "41582329", nombres = "Ana María", apellidos = "López Torres", FechaNacimiento = DateTime2("1954,08, 12") });
            personas.Add(new Personas { identificacion = "84632206", nombres = "Eugenio", apellidos = "Joya Rivera", FechaNacimiento = DateTime2("1984, 05, 17") });
            personas.Add(new Personas { identificacion = "7456977", nombres = "Carol Johanna", apellidos = "Pérez Castro", FechaNacimiento = DateTime2("1975, 02,5") });
            personas.Add(new Personas { identificacion = "15608542", nombres = "Pablo Raúl", apellidos = "Téllez Sánchez", FechaNacimiento = DateTime2("1949,01,19") });
            string result = ProcesarPersona(personas);
            return result;
        }

        public string ProcesarPersona(List<Personas> personas)
        {
            decimal Resultado1 = 0;
            decimal Resultado2 = 0;
            int valor = 0;
            DateTime fechaActual = new DateTime(2018, 3, 23);
            foreach (Personas p in personas)
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
            Personas p = new();
            DateTime fechaActual = new DateTime(2018, 3, 23);
            p = (new Personas { identificacion = "79658321", nombres = "Pedro Estiven", apellidos = "Gil Barón", FechaNacimiento = DateTime2("1979,10,26") });

            var A=("Identificación: { 0}; Nombres: { 1}; Apellidos: { 2}; Edad:{ 3}", p.identificacion, p.nombres, p.apellidos, calcularEdad(p.FechaNacimiento, fechaActual));
            var B=("Identificación: " +p.identificacion + " Nombres: " + p.nombres + "Apellidos: " +p.apellidos + "Edad: " +p.edad);
            var C=(String.Concat("Identificación: ", p.identificacion, "Nombres: ", p.nombres, "Apellidos: ", p.apellidos, "Edad: ", p.edad));
            //D a y b son correctas.
        }
    }
    public class Personas
    {
        public int? edad { get; set; }
        public string? identificacion { get; set; }
        public string? nombres { get; set; }
        public string? apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }

    }
}
//1 ¿Cuál es el resultado después de ejecutar el algoritmo?
//R / D Resultado 1: 69 Resultado 2: 49,8
//------------------------------------------------------------------------------
//2. ¿Cuál de las siguientes opciones muestra la información completa de la persona?
// NINGUNO-TODOS
//--------------------------------------------------------------------------------------------
//3.El concepto de las Siglas “M.V.C.” corresponde con la siguiente definición:
//a.Es un patrón de diseño útil para componentes de presentación.
//----------------------------------------------------------------------------------------------
//4. ¿Cuál de los siguientes patrones de diseño garantiza que un objeto se pueda instanciar una única
//vez en tiempo de ejecución?
//a. El patrón de diseño “Factory”
//b. El patrón de diseño “Unique Object”
//c. El patrón de diseño “Repository”
//d. Ninguna de las anteriores
//-------------------------------------------------------------------------------------------------------
//5.¿Cuál de las siguientes definiciones corresponde a las siglas “O.R.M.”?
//. Es una técnica de programación que permite convertir datos entre una base de datos relacional y el
//sistema de tipos soportado por un lenguaje de programación.
//----------------------------------------------------------------------------------------------------------
//6. ¿Cuál de las siguientes sentencias SQL, cumple con la siguiente consulta?: Consultar lista de
//empleados que tienen registrados un número de órdenes mayor o igual a cinco (5).
//    B)
//SELECT Empleados.Nombre, COUNT(Ordenes.ID) AS
//CantidadOrden
//FROM (Ordenes
//INNER JOIN Empleados ON Ordenes.EmpleadoId =
//Empleados.ID)
//GROUP BY Empleados.Nombre
//HAVING COUNT(Ordenes.ID) >= 5;
//------------------------------------------------------------------------------------------------------------
//7.Consultar los empleados por nombre y apellido, cuya edad no se encuentren en el rango entre 40
//y 50 años. ¿Cuál de las siguientes sentencias SQL, cumple con la condición anterior?:
//--d.
//SELECT Empleados.Nombre, Empleados.Apellido, datediff(yy, Empleados.FechaNacimiento, GETDATE())edad
//FROM Empleados
//WHERE (datediff(yy,Empleados.FechaNacimiento,GETDATE())not Between 40 and 50)

//----------------------------------------------------------------------------------------------------------
//8. Consultar empleados cuyos nombres comienzan con la palabra "Lu". ¿Cuál de las siguientes
//sentencias SQL, cumple con la condición anterior?:
//c 
//SELECT Empleados.Nombre
//FROM Empleados
//WHERE Empleados.Nombre LIKE 'Lu%';
//__________________________________________________________________________________________________________

//9. Realizar una consulta que contenga el nombre del empleado y la cantidad de órdenes que tenga
//asociadas, adicionalmente, se deben incluir los empleados que no contienen órdenes asociadas.
//¿Cuál de las siguientes sentencias SQL, cumple con la condición anterior?:
//d
//SELECT Empleados.Nombre, ISNULL(Count(Ordenes.ID),0)
//as CantidadOrden
//FROM Empleados LEFT JOIN Ordenes ON Empleados.ID =
//Ordenes.EmpleadoID
//Group By Empleados.Nombre;
//---------------------------------------------------------------------------------------------------------
//10.Dado los elementos alojados en la variable listItems, seleccione el bloque de código que permita filtrar los
//elementos contenidos de la variable listItems. Ejemplo: Si el usuario filtra por la cadena "Fer", se listarían
//Fernando y Fernanda. Si inserta la cadena "do", se listarían "Fernando" y "Armando".

//a.
//for (var i = 0; i < listItems.length; i++)
//{
//$('#listado').append('<li
//id = '+listItems[i]+' > '+listItems[i]+' </ li > ')
//}
//$('#Nombres').autocomplete({
//source: listItems,
//minLength: 1,
//select: function(event, ui){
//$('#Seleccionado').text('Seleccionado :
//'+ui.item.label)
//}
//})

//11.Dados el siguiente código en JavaScript y las siguientes sentencias. Seleccione las sentencias que
//al sustituirlas en el código coinciden con la funcionalidad que representa el algoritmo que valida
//y crea un objeto que describe características de una persona.

//    d. I:1, II: 3 y III:11


