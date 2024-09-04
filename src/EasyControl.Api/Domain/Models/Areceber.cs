using System.ComponentModel.DataAnnotations;

namespace EasyControl.Api.Domain.Models
{
    public class Areceber : Titulo
    {
        [Required(ErrorMessage = "O campo de Valor Recebido é obrigatório!")]
        public double ValorRecebido {get; set;}
        
        public DateTime? DataRecebimento {get; set;}
    }
}