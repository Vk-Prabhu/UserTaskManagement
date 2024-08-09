using System.Diagnostics.SymbolStore;

namespace TaskManagementSystem.BAL.Models
{
    public class LoginModel
    {
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword {  get; set; }
    }
}
