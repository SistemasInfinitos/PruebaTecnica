using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers.Persona
{
    public class PersonaWEBController : Controller
    {
        [HttpGet]
        public IActionResult Gestion()
        {
            return View();
        }
    }
}
