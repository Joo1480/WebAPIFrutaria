using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIFrutaria.Models;
using WebAPIFrutaria.Repositorios.Interfaces;

namespace WebAPIFrutaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _produtoRepoitorio;

        public ProdutoController(IProdutoRepositorio produtoRepoitorio)
        {
            _produtoRepoitorio = produtoRepoitorio;
        }
        [HttpGet]
        public async Task<ActionResult<List<ProdutoModel>>> BuscarTodosProdutos()
        {
            List<ProdutoModel> produto = await _produtoRepoitorio.BuscarTodosProdutos();
            return Ok(produto);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoModel>> BuscarPorId(int id)
        {
            ProdutoModel produto = await _produtoRepoitorio.BuscarPorId(id);
            return Ok(produto);
        }
        [HttpPost]
        public async Task<ActionResult<ProdutoModel>> Cadastrar([FromBody] ProdutoModel produtoModel)
        {
            ProdutoModel produto = await _produtoRepoitorio.Adicionar(produtoModel);
            return Ok(produto);
        }
    }
}
