namespace LoanModule.API.RequestModel
{
    public class GenericAPIRequestModel
    {
        public string ModuleName { get; set; } = string.Empty;
        public Dictionary<string, string> Parameter { get; set; } = new();
    }
}
