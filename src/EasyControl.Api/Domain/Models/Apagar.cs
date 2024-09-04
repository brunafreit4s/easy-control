using System.ComponentModel.DataAnnotations;

namespace EasyControl.Api.Domain.Models
{
    public class Apagar : Titulo
    {
        [Required(ErrorMessage = "O campo de Valor Pago é obrigatório!")]
        public double ValorPago {get; set;}
        
        public DateTime? DataPagamento {get; set;}

    }
}