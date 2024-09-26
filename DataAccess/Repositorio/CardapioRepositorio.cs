using Microsoft.EntityFrameworkCore;
using Dominio;
using Context;

namespace DataAccess;

public class CardapioRepositorio
{

    #region Atributos
    private readonly Contexto _contexto;

    #endregion


    #region Construtor
    public CardapioRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    #endregion


    #region Operações
    public void Salvar(Cardapio cardapio)
    {
        _contexto.Cardapios.Add(cardapio);
        _contexto.SaveChanges();

    }
    public void Deletar(Cardapio cardapio)
    {
        _contexto.Cardapios.Remove(cardapio);
        _contexto.SaveChanges();

    }
    public void Atualizar(Cardapio cardapio)
    {
        _contexto.Cardapios.Update(cardapio);
        _contexto.SaveChanges();
    }
    public Cardapio ObterCardapioPorId(int id)
    {
        var cardapio = _contexto.Cardapios.FirstOrDefault(cardapio => cardapio.Id == id);
        return cardapio;
    }
    public List<Cardapio> Listar()
    {
        return _contexto.Cardapios.ToList();
    }

    #endregion

}