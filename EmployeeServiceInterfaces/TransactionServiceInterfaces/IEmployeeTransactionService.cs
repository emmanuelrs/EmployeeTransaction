using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace TransactionServiceInterfaces
{
    [ServiceContract]
    public interface IEmployeeTransactionService
    {
        [OperationContract]
        void employee_registration(Employee employee);

        [OperationContract]
        List<Employee> GetEmployeesTransaction();
    }

    [DataContract]
    public class Employee
    {
        [DataMember]
        public string employee_id { set; get; }
        [DataMember]
        public string employee_name { set; get; }
        [DataMember]
        public string employee_first_surname { set; get; }
        [DataMember]
        public string employee_second_surname { set; get; }
        [DataMember]
        public string employee_email { set; get; }
        [DataMember]
        public string employee_username { set; get; }
        [DataMember]
        public string employee_salary { set; get; }
    }
}
