using System.Drawing.Drawing2D;
using BlueBud.Controllers;
using BlueBud.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlueBud.Data;


public class ApplicationDbContext : IdentityDbContext<ApplicationDbContext.BlueBudUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    public DbSet<Models.ChargerLocations> ChargerLocation{ get; set; }
    public class BlueBudUser: IdentityUser
    {
        public string FullName { get; set; }
        public string CarType { get; set; }
    }
    public DbSet<BlueBud.Models.CarTypeList> CarTypeList { get; set; } = default!;
    
}