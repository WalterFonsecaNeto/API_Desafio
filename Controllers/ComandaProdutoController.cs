using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Context;

[Route("api/[controller]")]
[ApiController]
public class ComandaProdutoController : Controller
{
    public static Contexto _contexto = new Contexto();
    private ComandaProdutoRepositorio comandaProdutoRepositorio = new ComandaProdutoRepositorio(_contexto);

    [HttpGet("{comandaProdutoId}")]
    public IActionResult Get([FromRoute] int comandaProdutoId)
    {
        var comandaProdutoEncontrado = comandaProdutoRepositorio.ObterComandaProdutoPorId(comandaProdutoId);

        if (comandaProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(comandaProdutoEncontrado);
        }
    }

    [HttpGet]
    public IActionResult ListarComandaProdutos()
    {
        return Ok(comandaProdutoRepositorio.Listar());
    }

    [HttpPost]
    public IActionResult Post([FromBody] ComandaProduto comandaProduto)
    {
        comandaProdutoRepositorio.Salvar(comandaProduto);
        return Ok();
    }

    [HttpPut("{comandaProdutoId}")]
    public IActionResult Put([FromRoute] int comandaProdutoId, [FromBody] ComandaProduto comandaProdutoEditado)
    {
        var comandaProdutoEncontrado = comandaProdutoRepositorio.ObterComandaProdutoPorId(comandaProdutoId);

        if (comandaProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {

            comandaProdutoEncontrado.ComandaID = comandaProdutoEditado.ComandaID;
            comandaProdutoEncontrado.ProdutoID = comandaProdutoEditado.ProdutoID;

            comandaProdutoRepositorio.Atualizar(comandaProdutoEncontrado);
            return NoContent();
        }
    }

    [HttpDelete("{comandaProdutoId}")]
    public IActionResult Delete([FromRoute] int comandaProdutoId)
    {
        var comandaProdutoEncontrado = comandaProdutoRepositorio.ObterComandaProdutoPorId(comandaProdutoId);
        
        if (comandaProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            comandaProdutoRepositorio.Deletar(comandaProdutoEncontrado);
            return NoContent();
        }
    }
}
