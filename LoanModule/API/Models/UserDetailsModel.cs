namespace LoanModule.API.Models
{
    public class UserDetailsModel
    {
        public int UserID { get; set; } 
        public string UserName { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
