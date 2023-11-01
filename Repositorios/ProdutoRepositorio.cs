using Microsoft.EntityFrameworkCore;
using WebAPIFrutaria.Data;
using WebAPIFrutaria.Models;
using WebAPIFrutaria.Repositorios.Interfaces;

namespace WebAPIFrutaria.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly FrutariaDBContext _dbContext;
        public ProdutoRepositorio(FrutariaDBContext FrutariaDBContext)
        {
            _dbContext = FrutariaDBContext;
        }
        public async Task<ProdutoModel> BuscarPorId(int id)
        {
            return await _dbContext.Produtos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<ProdutoModel>> BuscarTodosProdutos()
        {
            return await _dbContext.Produtos.ToListAsync();
        }
        public async Task<ProdutoModel> Adicionar(ProdutoModel produto)
        {
          await _dbContext.Produtos.AddAsync(produto);
            await _dbContext.SaveChangesAsync();

            return produto;            
        }

        public async Task<ProdutoModel> Atualizar(ProdutoModel produto, int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            produtoPorId.Nome = produto.Nome;
            produtoPorId.Valor = produto.Valor;            

            _dbContext.Produtos.Update(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return produtoPorId;

        }
        public async Task<bool> Apagar(int id)
        {
            ProdutoModel produtoPorId = await BuscarPorId(id);
            if (produtoPorId == null)
            {
                throw new Exception($"Produto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Produtos.Remove(produtoPorId);
            await _dbContext.SaveChangesAsync();

            return true;

        }
    }
}
