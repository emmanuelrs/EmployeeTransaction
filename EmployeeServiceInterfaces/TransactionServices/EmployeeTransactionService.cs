using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransactionDatabase;
using TransactionServiceInterfaces;

namespace TransactionServices
{
    public class EmployeeTransactionService : IEmployeeTransactionService
    {
        
        public void employee_registration(Employee employee)
        {
            EmployeeDatabase edbDatabase = new EmployeeDatabase();
            edbDatabase.employeeRegistration(employee.EmployeeName);
            
        }

        public Employee[] GetEmployeesTransaction()
        {
            EmployeeDatabase edbDatabase = new EmployeeDatabase();
            List<string> employee_list = edbDatabase.getEmployeeList();
            Employee[] employeeArray = new Employee[employee_list.Count];

            for (int i = 0; i < employee_list.Count; i++)
            {
                Employee employee = new Employee();
                employee.EmployeeName = employee_list[i];
                employeeArray[i] = employee;

            }
            return employeeArray;

        }
    }
}
