using LanchesMac.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext context) => _context = context;

        public string Id { get; set; }

        public List<CarrinhoCompraItem> Itens { get; set; }

        public static CarrinhoCompra Get(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            var context = services.GetService<AppDbContext>();

            return new CarrinhoCompra(context)
            {
                Id = carrinhoId
            };
        }

        public void Adicionar(Lanche lanche, int quantidade)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(x =>
                x.Lanche.Id == lanche.Id
                && x.CarrinhoCompraId == Id);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    Lanche = lanche,
                    Quantidade = 1,
                    CarrinhoCompraId = Id
                };

                _context.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }

            _context.SaveChanges();
        }

        public int Remover(Lanche lanche)
        {
            var carrinhoCompraItem = _context.CarrinhoCompraItem.SingleOrDefault(x =>
               x.Lanche.Id == lanche.Id
               && x.CarrinhoCompraId == Id);

            var quantidade = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidade = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.Remove(carrinhoCompraItem);
                }

                _context.SaveChanges();
            }

            return quantidade;
        }

        public List<CarrinhoCompraItem> GetItens()
        {
            return Itens ??
                (Itens = _context.CarrinhoCompraItem.Where(x =>
                x.CarrinhoCompraId == Id)
                    .Include(x => x.Lanche)
                    .ToList());
        }

        public void Limpar()
        {
            var itensCarrinho = _context.CarrinhoCompraItem.Where(x =>
                x.CarrinhoCompraId == Id);

            _context.CarrinhoCompraItem.RemoveRange(itensCarrinho);
            _context.SaveChanges();
        }

        public decimal GetValorTotal()
        {
            return _context.CarrinhoCompraItem.Where(x =>
                x.CarrinhoCompraId == Id)
                    .Select(x => x.Lanche.Preco * x.Quantidade)
                    .Sum();
        }
    }
}
