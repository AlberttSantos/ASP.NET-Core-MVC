using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanchesMac.Context;
using LanchesMac.Models;
using Microsoft.EntityFrameworkCore;

namespace LanchesMac.Repository
{
    public class LancheRepository : ILancheRepository
    {
        private readonly AppDbContext _context;
        public LancheRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Lanche> Lanches => _context.Lanche.Include(c => c.Categoria);

        public IEnumerable<Lanche> LanchePreferido => _context.Lanche.Where(x => x.IsLanchePreferido).Include(c => c.Categoria);

        public Lanche GetLancheById(int id)
        {
            return _context.Lanche.FirstOrDefault(x => x.Id == id);
        }
    }
}
