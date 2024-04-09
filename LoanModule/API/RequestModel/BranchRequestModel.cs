namespace LoanModule.API.RequestModel
{
    public class BranchRequestModel
    {
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? PhoneNo { get; set; }
        public bool status { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
