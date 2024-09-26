using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Dominio
{
    public class Cardapio
    {
       
        public int Id { get; set; }
        public bool Disponibilidade { get; set; }
        

        
        public List<CardapioProduto> Produtos { get; set; }
    }
}