namespace EasyControl.Api.Contract.Apagar
{
    public class ApagarRequestContract
    {
        public long IdNaturezaDeLancamento {get; set;}
        public string Descricao {get; set;} = string.Empty;
        public string Observacao {get; set;} = string.Empty;
        public double ValorOriginal {get; set;}
        public double ValorPago {get; set;}
        public DateTime? DataReferencia {get; set;}
        public DateTime DataVencimento {get; set;}
        public DateTime? DataPagamento {get; set;}
    }
}