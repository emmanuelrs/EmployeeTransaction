using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using TransactionsWebClient.Models;
using TransactionServiceInterfaces;

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
                using (ChannelFactory<IEmployeeTransactionService> transactionServiceProxy =
                    new ChannelFactory<IEmployeeTransactionService>("MyEmployeeServiceEndpoint"))
                {
                    transactionServiceProxy.Open();
                    IEmployeeTransactionService transactionService = transactionServiceProxy.CreateChannel();

                    List<TransactionServiceInterfaces.Employee> employee = transactionService.GetEmployeesTransaction();
                    return Json(new { Result = "OK", Records = employee});
                }
     
            }
            catch (Exception ex)
            {
                return Json(new { Result = "ERROR", Message = ex.Message });
            }
        }
        public ActionResult showEmployees()
        {
            return View();
        }
    }
}