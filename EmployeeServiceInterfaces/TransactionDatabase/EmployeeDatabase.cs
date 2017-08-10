using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
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
                SqlDataReader rdr = null;

                using (SqlTransaction tran = cn.BeginTransaction())
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("get_employee_info", cn, tran))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                Console.WriteLine(String.Format("{0}", rdr["employee_name"]));
                            }
                            rdr.Close();
                            

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
