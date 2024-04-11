namespace LoanModule.API.Models
{
    public class LoginModel
    {
        public char Flag { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
