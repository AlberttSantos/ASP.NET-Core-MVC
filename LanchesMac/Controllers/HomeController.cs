using LanchesMac.Repository;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class HomeController : Controller
    { 
        private readonly ILancheRepository _lancheRepository;

        public HomeController(ILancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                LanchesPreferidos = _lancheRepository.LanchePreferido
            };

            return View(homeViewModel);
        }
    }
}
