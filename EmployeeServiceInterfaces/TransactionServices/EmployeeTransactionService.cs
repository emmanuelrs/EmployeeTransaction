using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TransactionDatabase;
using TransactionServiceInterfaces;

namespace TransactionServices
{
    public class EmployeeTransactionService : IEmployeeTransactionService
    {
        
        public bool employee_registration(Employee employee)
        {
            Regex GmailRegex, IdRegex, userRegex;
            GmailRegex = new Regex(@"^[a-z0-9](\.?[a-z0-9]){5,}@g(oogle)?mail\.com$");
            IdRegex = new Regex(@"^[0-9]{1}-[0-9]{4}-[0-9]{4}$");
            userRegex = new Regex(@"^.*?(?=@)");

            if (Regex.IsMatch(employee.employee_id, IdRegex.ToString()))
            {
                if (Regex.IsMatch(employee.employee_email, GmailRegex.ToString()))
                {
                    Match username = Regex.Match(employee.employee_email, userRegex.ToString());
                    employee.employee_username = username.ToString();
                    EmployeeDatabase edbDatabase = new EmployeeDatabase();
                    edbDatabase.EmployeeRegistration(employee);

                    return true;

                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Employee> GetEmployeesTransaction()
        {
            EmployeeDatabase edbDatabase = new EmployeeDatabase();

            List<Employee> employeeList = edbDatabase.getEmployeeList();
            
            return employeeList;
       

        }
    }
}
