using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Jookli.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
    }
}
