using Microsoft.EntityFrameworkCore;
using Dominio;
using Context;

namespace DataAccess;

public class CardapioProdutoRepositorio
{

    #region Atributos
    private readonly Contexto _contexto;

    #endregion


    #region Construtor
    public CardapioProdutoRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    #endregion


    #region Operações
    public void Salvar(CardapioProduto cardapioProduto)
    {
        _contexto.CardapiosProdutos.Add(cardapioProduto);
        _contexto.SaveChanges();

    }
    public void Deletar(CardapioProduto cardapioProduto)
    {
        _contexto.CardapiosProdutos.Remove(cardapioProduto);
        _contexto.SaveChanges();

    }
    public void Atualizar(CardapioProduto cardapioProduto)
    {
        _contexto.CardapiosProdutos.Update(cardapioProduto);
        _contexto.SaveChanges();
    }
    public CardapioProduto ObterCardapioProdutoPorId(int id)
    {
        var cardapioProduto = _contexto.CardapiosProdutos.FirstOrDefault(cardapioProduto => cardapioProduto.Id == id);
        return cardapioProduto;
    }
    public List<CardapioProduto> Listar()
    {
        return _contexto.CardapiosProdutos.ToList();
    }

    #endregion

}