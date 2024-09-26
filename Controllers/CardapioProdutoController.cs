using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Context;

[Route("api/[controller]")]
[ApiController]
public class CardapioProdutoController : Controller
{
    public static Contexto _contexto = new Contexto();
    private CardapioProdutoRepositorio cardapioProdutoRepositorio = new CardapioProdutoRepositorio(_contexto);


    [HttpGet("{cardapioProdutoId}")]
    public IActionResult Get([FromRoute] int cardapioProdutoId)
    {
        var cardapioProdutoEncontrado = cardapioProdutoRepositorio.ObterCardapioProdutoPorId(cardapioProdutoId);

        if (cardapioProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(cardapioProdutoEncontrado);
        }
    }

    [HttpGet]
    public IActionResult ListarCardapioProdutos()
    {
        return Ok(cardapioProdutoRepositorio.Listar());
    }

    [HttpPost]
    public IActionResult Post([FromBody] CardapioProduto cardapioProduto)
    {
        cardapioProdutoRepositorio.Salvar(cardapioProduto);
        return Ok();
    }

    [HttpPut("{cardapioProdutoId}")]
    public IActionResult Put([FromRoute] int cardapioProdutoId, [FromBody] CardapioProduto cardapioProdutoEditado)
    {
        var cardapioProdutoEncontrado = cardapioProdutoRepositorio.ObterCardapioProdutoPorId(cardapioProdutoId);

        if (cardapioProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
           
            cardapioProdutoEncontrado.CardapioID = cardapioProdutoEditado.CardapioID;
            cardapioProdutoEncontrado.ProdutoID = cardapioProdutoEditado.ProdutoID;

            cardapioProdutoRepositorio.Atualizar(cardapioProdutoEncontrado);
            return NoContent();
        }
    }

    [HttpDelete("{cardapioProdutoId}")]
    public IActionResult Delete([FromRoute] int cardapioProdutoId)
    {
        var cardapioProdutoEncontrado = cardapioProdutoRepositorio.ObterCardapioProdutoPorId(cardapioProdutoId);
        
        if (cardapioProdutoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            cardapioProdutoRepositorio.Deletar(cardapioProdutoEncontrado);
            return NoContent();
        }
    }
}
