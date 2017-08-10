using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using TransactionServices;

namespace TransactionServiceHost
{
    class Program
    {
        static ServiceHost host = null;

        static void StartService()
        {
            host = new ServiceHost(typeof(EmployeeTransactionService));
            host.Open();
        }

        static void CloseService()
        {
            if (host.State != CommunicationState.Closed)
            {
                host.Close();
            }
        }
        static void Main(string[] args)
        {

            StartService();
            Console.WriteLine("Employee Service is running...");
            Console.ReadKey();

            CloseService();
        }
    }
}
