using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repository
{
    public interface ILancheRepository
    {
        IEnumerable<Lanche> Lanches { get; }
        IEnumerable<Lanche> LanchePreferido { get; }
        Lanche GetLancheById(int id);
    }
}
