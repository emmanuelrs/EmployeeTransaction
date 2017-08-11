using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TransactionsWebClient.Models
{
    public class Employee
    {
        [Required]
        public string employee_id { set; get; }
        [Required]
        public string employee_name { set; get; }
        [Required]
        public string employee_first_surname { set; get; }
       
        public string employee_second_surname { set; get; }
        [Required]
        public string employee_email { set; get; }
        public string employee_username { set; get; }
        public string employee_salary { set; get; }

        
    }
}