using Microsoft.EntityFrameworkCore;
using Dominio;
using Context;

namespace DataAccess;

public class ComandaRepositorio
{

  #region Atributos
    private readonly Contexto _contexto;

    #endregion


    #region Construtor
    public ComandaRepositorio(Contexto contexto)
    {
        _contexto = contexto;
    }

    #endregion


    #region Operações
    public void Salvar(Comanda comanda)
    {
        _contexto.Comandas.Add(comanda);
        _contexto.SaveChanges();

    }
    public void Deletar(Comanda comanda)
    {
        _contexto.Comandas.Remove(comanda);
        _contexto.SaveChanges();

    }
    public void Atualizar(Comanda comanda)
    {
        _contexto.Comandas.Update(comanda);
        _contexto.SaveChanges();
    }
    public Comanda ObterComandaPorId(int comandaID)
    {
        var comanda = _contexto.Comandas.FirstOrDefault(comanda => comanda.Id == comandaID);
        return comanda;
    }
          public List<Comanda> Listar()
    {
        return _contexto.Comandas.ToList();
    }

    #endregion

}