using LanchesMac.Repository;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace LanchesMac.Controllers
{
    public class LancheController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly ICategoriaRepository _categoriaRepository;

        public LancheController(ILancheRepository lancheRepository, ICategoriaRepository categoriaRepository)
        {
            _lancheRepository = lancheRepository;
            _categoriaRepository = categoriaRepository;
        }

        public IActionResult List()
        {
            //ViewBag.Lanche = "Teste de lanches";
            //ViewData["Categoria"] = "Categorias selecionadas";

            var lancheListViewModel = new LancheListViewModel
            {
                Lanches = _lancheRepository.Lanches,
                Categoria = "Hamburgueres"
            };

            return View(lancheListViewModel);
        }
    }
}