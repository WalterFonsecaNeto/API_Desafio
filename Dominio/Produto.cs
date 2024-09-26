namespace Dominio
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }



        public List<ComandaProduto> Comandas  { get; set; }
        public List<CardapioProduto> Cardapios  { get; set; }

    }
}