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
            edbDatabase.EmployeeRegistration(employee);
            
        }

        public List<Employee> GetEmployeesTransaction()
        {
            EmployeeDatabase edbDatabase = new EmployeeDatabase();

            List<Employee> employeeList = edbDatabase.getEmployeeList();
            
            return employeeList;
       

        }
    }
}
