using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        
        public string Nome { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(100)]
        [Display(Name = "Descrição" )]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço" )]
        public double? Preco { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int Estoque { get; set; }
    }
}