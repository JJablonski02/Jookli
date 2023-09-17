using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jookli.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
