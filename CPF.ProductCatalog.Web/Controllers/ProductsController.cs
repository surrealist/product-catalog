using Microsoft.AspNetCore.Mvc;

namespace CPF.ProductCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
