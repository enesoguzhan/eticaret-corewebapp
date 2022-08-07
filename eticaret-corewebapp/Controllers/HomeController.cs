using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace eticaret_corewebapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoriesService service;
        public HomeController(ICategoriesService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            var aa = service.GetAllCategoriesAsync().Result;
            return Json(service.GetAllCategoriesAsync().Result);
        }
    }
}
