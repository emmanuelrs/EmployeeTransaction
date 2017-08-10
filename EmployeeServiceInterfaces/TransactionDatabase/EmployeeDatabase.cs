using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;
using System.Windows.Forms;
using IsolationLevel = System.Transactions.IsolationLevel;

namespace TransactionDatabase
{
    public class EmployeeDatabase
    {
        private static List<string> employeeData = new List<string>();

        public void employeeRegistration(string employee_name)
        {
            employeeData.Add(employee_name);
            /*ConnectionStringSettings cnSettings = ConfigurationManager.ConnectionStrings["transaction_system"];
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnSettings.ConnectionString;
                cn.Open();

                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadCommitted;
                option.Timeout = TimeSpan.FromMinutes(5);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    
                }
            }*/

        }

        public List<string> getEmployeeList()
        {
            ConnectionStringSettings cnSettings = ConfigurationManager.ConnectionStrings["transaction_system"];
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnSettings.ConnectionString;
                cn.Open();

                SqlDataReader rdr = null;

                var option = new TransactionOptions();
                option.IsolationLevel = IsolationLevel.ReadCommitted;
                option.Timeout = TimeSpan.FromMinutes(5);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, option))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("get_employee_info", cn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                Console.WriteLine(String.Format("{0}", rdr["employee_name"]));
                            }
                            rdr.Close();
                        }
                        scope.Complete();

                    }
                    catch (Exception e)
                    {
                        scope.Dispose();
                        MessageBox.Show(e.Message);

                    }

                }
            }

            return employeeData;
        }
    }
}
