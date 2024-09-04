using System.ComponentModel.DataAnnotations;

namespace EasyControl.Api.Domain.Models
{
    public abstract class Titulo
    {
        [Key]
        public long Id {get; set;}

        [Required]
        public long IdUsuario {get; set;}

        [Required]
        public long IdNaturezaDeLancamento {get; set;}

        [Required(ErrorMessage = "O campo de Descrição é obrigatório!")]
        public string Descricao {get; set;} = string.Empty;
        
        public string? Observacao {get; set;} = string.Empty;

        [Required(ErrorMessage = "O campo de Valor Original é obrigatório!")]
        public double ValorOriginal {get; set;}        

        [Required]
        public DateTime DataCadastro {get; set;}
        
        [Required(ErrorMessage = "O campo de Data de Vencimento é obrigatório!")]
        public DateTime DataVencimento {get; set;}

        public DateTime? DataReferencia {get; set;}

        public DateTime? DataInativacao {get; set;}
        
        public Usuario Usuario {get; set;}
        
        public NaturezaDeLancamento NaturezaDeLancamento {get; set;}
    }
}