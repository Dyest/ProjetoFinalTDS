using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery.Models
{
    public class Favorito
    {   
         [Required]
        public int IdCliente { get; set; }
        [Required]
        public int IdProduto { get; set; }
        [Required]
        public DateTime DataHora {get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; set; }
        [ForeignKey("IdProduto")]
        public ProdutoModel Produto { get; set; }
        
    }
}