using Microsoft.AspNetCore.Mvc;

namespace Dock.UI.Site.Modules.Produtos.Controllers
{
    [Area("Produtos")]
    [Route("produtos")]
    public class CadastroController : Controller
    {
        [Route("lista")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("busca")]
        public IActionResult Busca()
        {
            return View();
        }
    }
}
