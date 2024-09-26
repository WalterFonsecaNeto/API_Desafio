using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using Dominio;

namespace Context;

public class Contexto : DbContext
{
    
    #region Atributos
    private string _stringConexao = "Server=DESKTOP-DCRAS3R\\SQLEXPRESS;Database=GerenciamentoDeComandas;TrustServerCertificate=true;Trusted_Connection=True;"; //Minha string de conexão com o banco de dados
    private DbContextOptions _options; //Uma variavel vazia do tipo DbContextoptions que vai receber uma option

    #endregion



    #region Propiedades
    public DbSet<Cardapio> Cardapios { get; set; }
    public DbSet<Comanda> Comandas { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<CardapioProduto> CardapiosProdutos { get; set; }
    public DbSet<ComandaProduto> ComandasProdutos { get; set; }


    #endregion



    #region Contrutores
    public Contexto() { }
    public Contexto(DbContextOptions options) : base(options)
    {
        _options = options;
    }

    #endregion



    #region Metodos e Funções

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_options == null)
        {
            optionsBuilder.UseSqlServer(_stringConexao);
        }
    }

    public IDbConnection CriarConexao()
    {
        var sqlConexao = new SqlConnection(_stringConexao);
        return sqlConexao;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ComandaConfiguration());
        modelBuilder.ApplyConfiguration(new CardapioConfiguration());
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new ComandaProdutoConfiguration());
        modelBuilder.ApplyConfiguration(new CardapioProdutoConfiguration());
    }

    #endregion
}