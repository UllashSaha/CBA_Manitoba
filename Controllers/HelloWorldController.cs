using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcBook.Controllers
{
    public class HelloWorldController : Controller
    {

        // 
        // GET: /HelloWorld/

        public IActionResult Index()
        {
            return View();
        }

        /* public string Index()
         {
             return "This is my default action...";
         }*/

        // 
        // GET: /HelloWorld/Welcome/ 

        /* public string Welcome()
         {
             return "This is the Welcome action method...";
         }*/
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["message"] = "Hello" + name;
            ViewData["NumTimes"] = numTimes;
            return View();
        }
        /*  public string Welcome(string name, int Id = 1)
          {


              return HtmlEncoder.Default.Encode($"Hello {name}, Id is: {Id}");
          }*/

    }
}
