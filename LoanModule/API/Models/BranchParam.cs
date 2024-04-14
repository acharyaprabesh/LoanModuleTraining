﻿namespace LoanModule.API.Models
{
    public class BranchParam
    {
        public char Flag { get; set; }
        public int BranchId { get; set; }
        public string BranchCode { get; set; } = string.Empty;
        public string BranchName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string? PhoneNo { get; set; }
        public bool status { get; set; }
        public DateTime CreatedDate { get; set; }= DateTime.Now;
        public int? CreatedBy { get; set; }
    }
}
