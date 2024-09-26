using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Context;

[Route("api/[controller]")]
[ApiController]

public class CardapioController : Controller
{
    public static Contexto _contexto = new Contexto();
    private CardapioRepositorio cardapioRepositorio = new CardapioRepositorio(_contexto);


    [HttpGet("{cardapioID}")]
    public IActionResult Get([FromRoute] int cardapioID)
    {
        var cardapioEncontrado = cardapioRepositorio.ObterCardapioPorId(cardapioID);

        if (cardapioEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(cardapioEncontrado);
        }


    }

    [HttpGet]
    public IActionResult ListarCardapio()
    {
        return Ok(cardapioRepositorio.Listar());

    }

    [HttpPost]
    public IActionResult Post([FromBody] Cardapio cardapio)
    {
        cardapioRepositorio.Salvar(cardapio);

        return Ok();
    }

    [HttpPut("{cardapioID}")]
    public IActionResult Put([FromRoute] int cardapioID, [FromBody] Cardapio cardapioEditado)
    {
        var cardapioEncontrado = cardapioRepositorio.ObterCardapioPorId(cardapioID);

        if (cardapioEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            cardapioEncontrado.Disponibilidade = cardapioEditado.Disponibilidade;

            cardapioRepositorio.Atualizar(cardapioEncontrado);

            return NoContent();
        }

    }

    [HttpDelete("{cardapioID}")]
    public IActionResult Delete([FromRoute] int cardapioID)
    {
        var cardapioEncontrado = cardapioRepositorio.ObterCardapioPorId(cardapioID);
        if (cardapioEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            cardapioRepositorio.Deletar(cardapioEncontrado);

            return NoContent();
        }
    }

}