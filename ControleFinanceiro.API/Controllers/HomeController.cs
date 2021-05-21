using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.API.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        [HttpGet]
        public object Home()
        {
            return new { Message = "Hello word" };
        }
    }
}