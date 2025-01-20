using Microsoft.AspNetCore.Identity;

namespace LibApp.Models
{
    public class Users : IdentityUser
    {
        public string FullName { get; set; }
        public int BooksIssued { get; set; }
    }
}
