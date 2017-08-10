using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransactionDatabase
{
    public class EmployeeDatabase
    {
        private static List<string> employeeData = new List<string>();

        public void employeeRegistration(string employee_name)
        {
            employeeData.Add(employee_name);
        }

        public List<string> getEmployeeList()
        {
            return employeeData;
        }
    }
}
