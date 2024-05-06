namespace Authenticator.Models;
using Microsoft.EntityFrameworkCore;
public class UserDataContext:DbContext
{
    public UserDataContext(DbContextOptions<UserDataContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users;
}