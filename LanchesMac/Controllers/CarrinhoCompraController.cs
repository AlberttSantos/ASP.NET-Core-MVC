using LanchesMac.Models;
using LanchesMac.Repository;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LanchesMac.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly ILancheRepository _lancheRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(ILancheRepository lancheRepository, CarrinhoCompra carrinhoCompra)
        {
            _lancheRepository = lancheRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            _carrinhoCompra.Itens = _carrinhoCompra.GetItens();

            var carrinhoCompra = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                Total = _carrinhoCompra.GetValorTotal()
            };

            return View(carrinhoCompra);
        }

        public IActionResult Adicionar(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.Id == lancheId);

            if (lanche != null)
                _carrinhoCompra.Adicionar(lanche, 1);

            return RedirectToAction("Index");
        }

        public IActionResult Remover(int lancheId)
        {
            var lanche = _lancheRepository.Lanches.FirstOrDefault(x => x.Id == lancheId);

            if (lanche != null)
                _carrinhoCompra.Remover(lanche);

            return RedirectToAction("Index");
        }
    }
}