using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class AppUser : IdentityUser // no need to add BaseEntity here since we are applying IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
      

    }

   
}