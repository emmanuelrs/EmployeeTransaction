using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TransactionWebService.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Goog Morning" : "Good Afternoon";  
            return View();
        }


        public ViewResult show_employees()
        {
            return View();
        }
    }
}