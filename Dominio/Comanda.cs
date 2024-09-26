namespace Dominio
{
    public class Comanda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string NomeGarcom { get; set; }
        public int Mesa { get; set; }



        public List<ComandaProduto>Produtos { get; set; }

    }
}