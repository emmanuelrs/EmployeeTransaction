using System;
using System.Collections.Generic;
using System.Diagnostics;
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
                    return Json(new {Result = "OK", Records = employee});
                }

            }
            catch (Exception ex)
            {
                return Json(new {Result = "ERROR", Message = ex.Message});
            }
        }

        [HttpPost]
        public JsonResult CreateEmployee(Employee employee)
        {
            try
            {
                using (ChannelFactory<IEmployeeTransactionService> transactionServiceProxy =
                    new ChannelFactory<IEmployeeTransactionService>("MyEmployeeServiceEndpoint"))
                {
                    transactionServiceProxy.Open();
                    IEmployeeTransactionService transactionService = transactionServiceProxy.CreateChannel();
                    if (!ModelState.IsValid)
                    {
                        return Json(new
                        {
                            Result = "ERROR",
                            Message = "Form is not valid! " +
                                      "Please correct it and try again."
                        });
                    }
                    

                    var result = transactionService.employee_registration(employee);

                    if (result)
                    {
                        return Json(new {Result = "OK", Record = employee});
                    }
                    else
                    {
                        return Json(new { Result = "ERROR", Message = "Invalid Regex Fields" });
                    }
                    
                    


                }

            }
            catch (Exception e)
            {
                
                return Json(new {Result = "ERROR", Message = e.Message});
            }
       
      }
    

    public ActionResult showEmployees()
        {
            return View();
        }
    }
}