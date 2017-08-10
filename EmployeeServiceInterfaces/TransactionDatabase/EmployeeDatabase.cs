using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

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
            ConnectionStringSettings cnSettings = ConfigurationManager.ConnectionStrings["transaction_system"];
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnSettings.ConnectionString;
                cn.Open();
                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = cn.CreateCommand())
                        {
                            Console.WriteLine("Hello");
                            //cmd.Transaction = tran;
                            //cmd.CommandText = 
                        }

                    }
                    catch (Exception e)
                    {
                        tran.Rollback();
                        MessageBox.Show(e.Message);
                        
                    }
                }
            }

            return employeeData;
        }
    }
}
