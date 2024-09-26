using Microsoft.EntityFrameworkCore;
using Dominio;
using Context;

namespace DataAccess;

public class ComandaProdutoRepositorio
{

    #region Atributos
    private readonly Contexto _contexto;

    #endregion


    #region Construtor
    public ComandaProdutoRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    #endregion


    #region Operações
    public void Salvar(ComandaProduto comandaProduto)
    {
        _contexto.ComandasProdutos.Add(comandaProduto);
        _contexto.SaveChanges();

    }
    public void Deletar(ComandaProduto comandaProduto)
    {
        _contexto.ComandasProdutos.Remove(comandaProduto);
        _contexto.SaveChanges();

    }
    public void Atualizar(ComandaProduto comandaProduto)
    {
        _contexto.ComandasProdutos.Update(comandaProduto);
        _contexto.SaveChanges();
    }
    public ComandaProduto ObterComandaProdutoPorId(int id)
    {
        var comandaProduto = _contexto.ComandasProdutos.FirstOrDefault(comandaProduto => comandaProduto.Id == id);
        return comandaProduto;
    }
    public List<ComandaProduto> Listar()
    {
        return _contexto.ComandasProdutos.ToList();
    }

    #endregion

}