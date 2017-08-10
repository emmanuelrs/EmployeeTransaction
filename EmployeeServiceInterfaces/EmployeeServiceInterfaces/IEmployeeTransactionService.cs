using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace EmployeeServiceInterfaces
{
    [ServiceContract]
    public interface IEmployeeTransactionService
    {
        [OperationContract]
        void employeeTransaction(Employee employee);

        [OperationContract]
        Employee[] GetEmployeesTransaction();
    }

    [DataContract]
    public class Employee
    {
        private string employee_name;

        [DataMember]
        public string EmployeeName
        {
            set { this.employee_name = value; }
            get { return this.employee_name; }
        }
    }
}
