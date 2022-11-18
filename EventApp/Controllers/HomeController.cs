using EventApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EventApp.Controllers
{
    
    public class HomeController : Controller
    {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}