using DataAccess;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Context;
using Models;

[Route("api/[controller]")]
[ApiController]

public class ProdutoController : Controller
{
    public static Contexto _contexto = new Contexto();
    private ProdutoRepositorio produtoRepositorio = new ProdutoRepositorio(_contexto);

    [HttpGet]
    [Route("buscar/{produtoID}")]
    public IActionResult Get([FromRoute] int produtoID)
    {
        var produtoEncontrado = produtoRepositorio.ObterProdutoPorId(produtoID);

        if (produtoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(produtoEncontrado);
        }


    }

    [HttpGet]
    [Route("listar")]
    public IActionResult ListarProdutos()
    {
        return Ok(produtoRepositorio.Listar());

    }

    [HttpPost]
    [Route("criar")]
    public IActionResult Post([FromBody] ProdutoNovo produtoModificado)
    {
        Produto produto = new Produto()
        {
            Nome = produtoModificado.Nome,
            Preco = produtoModificado.Preco
            
        };
        produtoRepositorio.Salvar(produto);

        return Ok();
    }

    [HttpPut]
    [Route("atualizar/{produtoID}")]
    public IActionResult Put([FromRoute] int produtoID, [FromBody] ProdutoNovo produtoEditado)
    {
        var produto =  new Produto() { 
            Nome = produtoEditado.Nome,
            Preco = produtoEditado.Preco
        };

        var produtoEncontrado = produtoRepositorio.ObterProdutoPorId(produtoID);

        if (produtoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            produtoEncontrado.Nome = produto.Nome;
            produtoEncontrado.Preco = produto.Preco;

            produtoRepositorio.Atualizar(produtoEncontrado);

            return NoContent();
        }

    }

    [HttpDelete]
    [Route("deletar/{produtoID}")]
    public IActionResult Delete([FromRoute] int produtoID)
    {
        var produtoEncontrado = produtoRepositorio.ObterProdutoPorId(produtoID);
        if (produtoEncontrado == null)
        {
            return NotFound();
        }
        else
        {
            produtoRepositorio.Deletar(produtoEncontrado);

            return NoContent();
        }
    }

}