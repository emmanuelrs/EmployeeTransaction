using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TransactionWebClient.Models
{
    public class EmployeeTransaction
    {
        public string employee_id { set; get; }
        public string employee_name { set; get; }
        public string employee_first_surname { set; get; }
        public string employee_second_surname { set; get; }
        public string employee_email { set; get; }
        public string employee_user { set; get; }
        public string employee_salary { set; get; }
    }
}