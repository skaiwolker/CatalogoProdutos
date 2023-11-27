using CatalogoProdutos.Data;
using CatalogoProdutos.Models;
using CatalogoProdutos.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace CatalogoProdutos.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Add(Produto produto)
        {
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Produto produto)
        {
            _context.Remove(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto?> GetProdutoById(Guid id)
        {
            Produto? produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == id);

            return produto;
        }

        public async Task<List<Produto>> GetAll(int page)
        {
            List<Produto> allProdutos = await _context.Produtos.ToListAsync();

            if (allProdutos.Count <= 5) return allProdutos;

            List<Produto> pagedProdutos = new();      

            if (page == 1) 
            {
                for (int i = 0; i < 5; i++)
                {
                    pagedProdutos.Add(allProdutos[i]);
                }

                return pagedProdutos;
            }

            for (int i = 5 * (page - 1); i < allProdutos.Count; i++)
            {
                pagedProdutos.Add(allProdutos[i]);
            }

            return pagedProdutos;
        }

        public async Task<int> ProdutosCount()
        {
            List<Produto> produtos = await _context.Produtos.ToListAsync();

            return produtos.Count;
        }
    }
}
