using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace delivery.Models
{
    public class PedidoModel
    {
         public enum SituacaoPedido
        {
            Realizado,
            Verificado,
            Atendido,
            Entregue,
            Cancelado
        }

        [Key]
        [Display(Name = "Código")]
        public int IdPedido { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Data/Hora")]
        public DateTime DataHoraPedido { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [Display(Name = "Valor Total")]
        public decimal ValorTotal { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [DisplayName("Situação")]
        public SituacaoPedido Situacao { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public ClienteModel Cliente { get; }
        public EnderecoModel Endereco { get; set; }
        public ICollection<ItemPedidoModel> ItensPedido { get; set; }
    }
}