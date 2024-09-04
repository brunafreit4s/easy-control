namespace EasyControl.Api.Contract
{
    public class ErrorContract
    {
        public int Status {get; set;}
        public string Title {get; set;}
        public string Message {get; set;}
        public DateTime DateTime {get; set;}
    }
}