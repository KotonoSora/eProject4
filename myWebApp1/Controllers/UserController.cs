using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myWebApp1.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public string Index() {
            return "ahihi this is index";
        }

        public string ChaoMung(string ten, int tuoi = 1) {
            return "ahihi hi:"+ ten+" age: "+ tuoi;
        }
    }
}
