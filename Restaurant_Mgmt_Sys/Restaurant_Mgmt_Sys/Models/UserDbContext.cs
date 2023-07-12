using Microsoft.EntityFrameworkCore;

namespace Restaurant_Mgmt_Sys.Models
{
    public class UserDbContext:DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options): base(options) 
        { }
        

    }
}
