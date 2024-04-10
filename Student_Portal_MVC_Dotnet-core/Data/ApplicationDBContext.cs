using Microsoft.EntityFrameworkCore;
using Student_Portal_MVC_Dotnet_core.Models.Entities;

namespace Student_Portal_MVC_Dotnet_core.Data;

public class ApplicationDBContext : DbContext
{

    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
    {
        
    }
    
    public DbSet<Student> Students { get; set; }
    
}