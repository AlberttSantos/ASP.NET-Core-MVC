using LanchesMac.Models;
using LanchesMac.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LanchesMac.Components
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompra carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            //_carrinhoCompra.Itens = _carrinhoCompra.GetItens();
            _carrinhoCompra.Itens = new List<CarrinhoCompraItem>() { new CarrinhoCompraItem(), new CarrinhoCompraItem() };
            var carrinhoCompraViewModel = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                Total = _carrinhoCompra.GetValorTotal()
            };

            return View(carrinhoCompraViewModel);
        }
    }
}
