using Microsoft.EntityFrameworkCore;
using Dominio;
using Context;

namespace DataAccess;
public class ProdutoRepositorio
{
    #region Atributos
    private readonly Contexto _contexto;

    #endregion


    #region Construtor
    public ProdutoRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    #endregion


    #region Operações
    public void Salvar(Produto produto)
    {
        _contexto.Produtos.Add(produto);
        _contexto.SaveChanges();

    }
    public void Deletar(Produto produto)
    {
        _contexto.Produtos.Remove(produto);
        _contexto.SaveChanges();

    }
    public void Atualizar(Produto produto)
    {
        _contexto.Produtos.Update(produto);
        _contexto.SaveChanges();
    }
    public Produto ObterProdutoPorId(int produtoID)
    {
        var produto = _contexto.Produtos.FirstOrDefault(produto => produto.Id == produtoID);
        return produto;
    }
    public List<Produto> Listar()
    {
        return _contexto.Produtos.ToList();
    }

    #endregion
}