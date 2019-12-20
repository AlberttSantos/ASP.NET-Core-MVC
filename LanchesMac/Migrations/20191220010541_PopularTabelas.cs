using Microsoft.EntityFrameworkCore.Migrations;

namespace LanchesMac.Migrations
{
    public partial class PopularTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categoria (Nome, Descricao) VALUES('Normal', 'Lanche simples e normal')");
            migrationBuilder.Sql("INSERT INTO Categoria (Nome, Descricao) VALUES('Natural', 'Lanche fitness')");

            migrationBuilder.Sql(@"INSERT INTO Lanche
            (Nome, DescricaoCurta, DescricaoDetalhada, Preco, ImagemUrl, ImagemThumbnailUrl, IsLanchePreferido, EmEstoque, CategoriaId)
            VALUES('x-frango', 'Hamburguer de frango', 'musarela queijo ovo e frango', 15, 'imagemUrl', 'ImagemThumbnailUrl', 1, 1, 1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categorias");
            migrationBuilder.Sql("DELETE FROM Lanches");
        }
    }
}
