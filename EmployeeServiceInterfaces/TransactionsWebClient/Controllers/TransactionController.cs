using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TransactionsWebClient.Models;

namespace TransactionsWebClient.Controllers
{
    public class TransactionController : Controller
    {
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult EmployeeList()
        {
            try
            {
                List<Employee> employee = _repository.PersonRepository.GetAllPeople();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        public ActionResult showEmployees()
        {
            return View();
        }
    }
}