using Microsoft.EntityFrameworkCore;
using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Identity.Infrastructure.Configurations;

namespace Identity.Infrastructure
{
    public class AuthDbContext:IdentityDbContext<User>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
