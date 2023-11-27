using CatalogoProdutos.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Services.Interface
{
    public interface IProdutoService
    {
        Task Add(Produto produto);
        Task Update(Produto produto);
        Task Delete(Produto produto);
        Task<Produto?> GetProdutoById(Guid id);
        Task<List<Produto>> GetAll(int page);
        Task<int> ProdutosCount();
    }
}
