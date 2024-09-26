using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Context;

[Route("api/[controller]")]
[ApiController]
public class ComandaController : Controller
{
    public static Contexto _contexto = new Contexto();
    private ComandaRepositorio comandaRepositorio = new ComandaRepositorio(_contexto);

    [HttpGet("{comandaId}")]
    public IActionResult Get([FromRoute] int comandaId)
    {
        var comandaEncontrada = comandaRepositorio.ObterComandaPorId(comandaId);

        if (comandaEncontrada == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(comandaEncontrada);
        }
    }

    [HttpGet]
    public IActionResult ListarComandas()
    {
        return Ok(comandaRepositorio.Listar());
    }

    [HttpPost]
    public IActionResult Post([FromBody] Comanda comanda)
    {
        comandaRepositorio.Salvar(comanda);
        return Ok();
    }

    [HttpPut("{comandaId}")]
    public IActionResult Put([FromRoute] int comandaId, [FromBody] Comanda comandaEditada)
    {
        var comandaEncontrada = comandaRepositorio.ObterComandaPorId(comandaId);

        if (comandaEncontrada == null)
        {
            return NotFound();
        }
        else
        {
            comandaEncontrada.Data = comandaEditada.Data; 
            comandaEncontrada.NomeGarcom = comandaEditada.NomeGarcom; 
            comandaEncontrada.Mesa = comandaEditada.Mesa; 
           
            comandaRepositorio.Atualizar(comandaEncontrada);
            return NoContent();
        }
    }

    [HttpDelete("{comandaId}")]
    public IActionResult Delete([FromRoute] int comandaId)
    {
        var comandaEncontrada = comandaRepositorio.ObterComandaPorId(comandaId);
        
        if (comandaEncontrada == null)
        {
            return NotFound();
        }
        else
        {
            comandaRepositorio.Deletar(comandaEncontrada);
            return NoContent();
        }
    }
}
