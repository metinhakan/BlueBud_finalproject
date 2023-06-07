using System.Diagnostics;
using BlueBud.Data;
using Microsoft.AspNetCore.Mvc;
using BlueBud.Models;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace BlueBud.Controllers;

public class HomeController : Controller
{
    public bool UserLoggedIn;
    private readonly ApplicationDbContext dbContext;
    public bool isFull;
    
    
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    

    [Authorize]
    public IActionResult Index()
    {
        if (User.Identity.IsAuthenticated)
        {
            UserLoggedIn = true;
        }
        
        else 
        {
            UserLoggedIn = false;
        }

        ViewBag.IsAut = UserLoggedIn;
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(local);Database=BlueBuddy;User ID=sa;Password=Aa123456;MultipleActiveResultSets=true;Trust Server Certificate = true")
            .Options;


        
        using (var dbContext = new ApplicationDbContext(options))
        {
            List<ChargerLocations> top5Charger =
                dbContext.ChargerLocation.Where(p => p.OccupationStatus == 0 ).Take(4).ToList();
            return View(top5Charger);
        }
        
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    [Authorize]
    public IActionResult Account()
    {
        return View();
    }

   

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public IActionResult Reservations()
    {
        
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer("Server=(local);Database=BlueBuddy;User ID=sa;Password=Aa123456;MultipleActiveResultSets=true;Trust Server Certificate = true")
            .Options;


        
        using (var dbContext = new ApplicationDbContext(options))
        {
            
            List<ChargerLocations> resserved4charger =
                dbContext.ChargerLocation.Where(p => p.OccupationStatus == 1 ).Take(4).ToList();
            
            if (resserved4charger == null)
            {
                isFull = false;
            }
            else
            {
                isFull = true;
            }

            ViewBag.ListFull = isFull;
            
            
            return View(resserved4charger);

           
            
        }
        
    }
    

    

}
