using LanchesMac.Models;
using System.Collections.Generic;

namespace LanchesMac.Repository
{
    public interface ICategoriaRepository
    {
        IEnumerable<Categoria> Categorias { get; }
    }
}
