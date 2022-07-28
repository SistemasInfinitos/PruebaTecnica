using CanonicalModel.Model.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace WEB.Controllers.Prueba
{
    [Route("api/[controller]")]
    [ApiController]
    public class SumitempApiController : ControllerBase
    {
        [Route("[action]", Name = "GetTest")]
        [HttpGet]
        public async Task<IActionResult> GetTest()
        {
            AuthResult responseClient = new AuthResult();

            responseClient.Errors.Add("Su sesión a Caducado, Acceso denegado!");
            return BadRequest(new {responseClient});
        }

    }
}
